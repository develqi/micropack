using System;
using MediatR;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Micropack.ESCQRS
{
    public static class IoC
    {
        public static void AddESCQRSServices(this IServiceCollection services)
        {
            services.AddScoped<IQueryBus, QueryBus>().AddTransient(serviceProvider => new Lazy<IQueryBus>(() => serviceProvider.GetRequiredService<IQueryBus>()));
            services.AddScoped<IEventBus, EventBus>().AddTransient(serviceProvider => new Lazy<IEventBus>(() => serviceProvider.GetRequiredService<IEventBus>()));
            services.AddScoped<ICommandBus, CommandBus>().AddTransient(serviceProvider => new Lazy<ICommandBus>(() => serviceProvider.GetRequiredService<ICommandBus>()));

            ConfigureMediator(services);
        }

        private static void ConfigureMediator(IServiceCollection services)
        {
            services.AddScoped<IMediator, Mediator>();
            services.AddTransient<ServiceFactory>(sp => t => sp.GetService(t));
        }

        public static void AddCommandHandlersFromAssemblyContaining<TCommandHandler, TCommand>(this IServiceCollection services, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
            where TCommand : ICommand
            where TCommandHandler : ICommandHandler<TCommand>
        {
            var assembly = typeof(TCommandHandler).Assembly;

            assembly.GetTypes()
                    .Where(type => type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommandHandler<>)))
                    .Select(type => new
                    {
                        Handler = type,
                        GenericArguments = type.GetInterfaces().FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommandHandler<>)).GetGenericArguments()
                    })
                    .Select(type => new
                    {
                        Handler = type.Handler,
                        TCommand = type.GenericArguments[0],
                    })
                    .ToList()
                    .ForEach(type => services.Add(new ServiceDescriptor(typeof(IRequestHandler<,>).MakeGenericType(type.TCommand, typeof(Unit)), type.Handler, serviceLifetime)));
        }

        public static void AddQueryHandlersFromAssemblyContaining<TQueryHandler, TQuery, TResponse>(this IServiceCollection services, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
            where TQuery : IQuery<TResponse>
            where TQueryHandler : IQueryHandler<TQuery, TResponse>
        {
            var assembly = typeof(TQueryHandler).Assembly;

            assembly.GetTypes()
                    .Where(type => type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IQueryHandler<,>)))
                    .Select(type => new
                    {
                        Handler = type,
                        GenericArguments = type.GetInterfaces().FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IQueryHandler<,>)).GetGenericArguments()
                    })
                    .Select(type => new
                    {
                        Handler = type.Handler,
                        TQuery = type.GenericArguments[0],
                        TResponse = type.GenericArguments[1]
                    })
                    .ToList()
                    .ForEach(type => services.Add(new ServiceDescriptor(typeof(IRequestHandler<,>).MakeGenericType(type.TQuery, type.TResponse), type.Handler, serviceLifetime)));
        }

        public static void AddPaginationQueryHandlersFromAssemblyContaining<TPaginationQueryHandler, TPaginationQuery, TResponse>(this IServiceCollection services, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
           where TPaginationQuery : PaginationQuery<TResponse>
           where TPaginationQueryHandler : IPaginationQueryHandler<TPaginationQuery, TResponse>
           where TResponse : class
        {
            var assembly = typeof(TPaginationQueryHandler).Assembly;

            assembly.GetTypes()
                    .Where(type => type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IPaginationQueryHandler<,>)))
                    .Select(type => new
                    {
                        Handler = type,
                        GenericArguments = type.GetInterfaces().FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IPaginationQueryHandler<,>)).GetGenericArguments()
                    })
                    .Select(type => new
                    {
                        Handler = type.Handler,
                        TQuery = type.GenericArguments[0],
                        TResponse = type.GenericArguments[1]
                    })
                    .ToList()
                    .ForEach(type => services.Add(new ServiceDescriptor(typeof(IRequestHandler<,>).MakeGenericType(type.TQuery, type.TResponse), type.Handler, serviceLifetime)));
        }
    }
}

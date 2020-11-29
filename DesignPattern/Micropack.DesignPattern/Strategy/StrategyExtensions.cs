using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Micropack.DesignPattern.Strategy
{
    public static class StrategyExtensions
    {
        internal static void RegisterImplementedStrategiesFromType(this IServiceCollection services, Type strategyType, ServiceLifetime serviceLifetime = ServiceLifetime.Singleton)
        {
            strategyType.Assembly
                        .GetTypes()
                        .Where(type => type.IsClass)
                        .Where(type => !type.IsAbstract)
                        .Where(type => strategyType.IsAssignableFrom(type))
                        .ToList().ForEach(type => services.Add(new ServiceDescriptor(type, type, serviceLifetime)));
        }

        internal static void RegisterStrategy<TStrategy>(this IServiceCollection services, ServiceLifetime serviceLifetime = ServiceLifetime.Singleton) where TStrategy : IStrategy
        {
            services.AddScoped<Func<Enum, TStrategy>>(provider => type =>
            {
                var strategyType = typeof(TStrategy);

                var typeName = $"{strategyType.Namespace}.{type.ToString()}{strategyType.Name}";

                var neededStrategy = strategyType.Assembly.GetType(typeName);

                return (TStrategy)provider.GetRequiredService(neededStrategy);
            });
        }

        public static void RegisterStrategiesFromAssemblyContaining<TStrategy>(this IServiceCollection services, ServiceLifetime serviceLifetime = ServiceLifetime.Singleton) where TStrategy : IStrategy
        {
            typeof(TStrategy).Assembly.GetTypes()
                        .Where(type => typeof(IStrategy).IsAssignableFrom(type))
                        .Where(type => type.IsInterface || (type.IsClass && type.IsAbstract))
                        .ToList().ForEach(type =>
                        {
                            services.RegisterImplementedStrategiesFromType(type, serviceLifetime);

                            services.RegisterStrategy<TStrategy>(serviceLifetime);
                        });

            ServiceLocator.SetLocatorProvider(services.BuildServiceProvider());
        }
    }
}

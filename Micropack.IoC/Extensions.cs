using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Micropack.IoC
{
    public static class Extensions
    {
        // Auto register services from assembly
        public static void AddAutoRegisterServicesFromAssemblyContaining<TService>(this IServiceCollection services)
        {
            var assembly = typeof(TService).Assembly;

            assembly.GetTypes()
                    .Where(type => type.IsClass)
                    .Where(type => type.GetCustomAttributes().Any(attr => attr.GetType() == typeof(AutoRegisterAttribute)))
                    .ToList()
                    .ForEach(type =>
                    {
                        var attribute = type.GetCustomAttribute(typeof(AutoRegisterAttribute));

                        var serviceLifetime = (ServiceLifetime)attribute.GetType().GetProperty("ServiceLifetime").GetValue(attribute);

                        services.Add(new ServiceDescriptor(type, type, serviceLifetime));
                    });
        }
    }
}

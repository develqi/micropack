using Microsoft.Extensions.DependencyInjection;

namespace Micropack.DateTimeProviders
{
    public static class IServiceCollectionExtensions
    {
        public static void AddDateTimeProviderServices(this IServiceCollection services) 
        {
            services.AddSingleton<ITodayProvider, TodayProvider>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        }
    }
}

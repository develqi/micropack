using Microsoft.Extensions.DependencyInjection;

namespace Micropack.AspNetCore.RedisCache
{
    public static class IServiceCollectionExtensions
    {
        public static void AddRedisConfig(this IServiceCollection services, RedisCacheSettings setting)
        {
            //services.AddSingleton(setting);

            //if (!setting.Enabled) return;

            //services.AddStackExchangeRedisCache(options => options.Configuration = setting.ConnectionString);

            //// Below code applied with ISingletonDependency Interface
            //// services.AddSingleton<IResponseCacheService, ResponseCacheService>();
        }
    }
}

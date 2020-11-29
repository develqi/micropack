using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Micropack.AspNetCore.RedisCache;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Micropack.AspNetCore.RedisCache
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CachedAttribute : Attribute, IAsyncActionFilter
    {
        private readonly int _secondsToCache;
        private readonly bool _useDefaultCacheSeconds;

        public CachedAttribute()
        {
            _useDefaultCacheSeconds = true;
        }

        public CachedAttribute(int secondsToCache)
        {
            _secondsToCache = secondsToCache;
            _useDefaultCacheSeconds = false;
        }

        private static string GenerateCacheKeyFromRequest(HttpRequest httpRequest)
        {
            var keyBuilder = new StringBuilder();
            keyBuilder.Append($"{httpRequest.Path}");

            foreach (var (key, value) in httpRequest.Query.OrderBy(x => x.Key))
            {
                keyBuilder.Append($"|{key}-{value}");
            }

            return keyBuilder.ToString();
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var cacheSettings = context.HttpContext.RequestServices.GetRequiredService<RedisCacheSettings>();

            if (!cacheSettings.Enabled)
            {
                await next();
                return;
            }

            var cacheService = context.HttpContext.RequestServices.GetRequiredService<IResponseCacheService>();

            // Check if request has Cache
            var cacheKey = GenerateCacheKeyFromRequest(context.HttpContext.Request);
            var cachedResponse = await cacheService.GetCachedResponseAsync(cacheKey);

            // If Yes => return Value
            if (!string.IsNullOrWhiteSpace(cachedResponse))
            {
                var contentResult = new ContentResult
                {
                    Content = cachedResponse,
                    ContentType = "application/json",
                    StatusCode = 200
                };
                context.Result = contentResult;
                return;
            }

            // If No => Go to method => Cache Value
            var actionExecutedContext = await next();

            if (actionExecutedContext.Result is OkObjectResult okObjectResult)
            {
                var secondsToCache = _useDefaultCacheSeconds ? cacheSettings.DefaultSecondsToCache : _secondsToCache;
                await cacheService.CacheResponseAsync(cacheKey, okObjectResult.Value,
                    TimeSpan.FromSeconds(secondsToCache));
            }
        }
    }
}

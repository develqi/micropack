using System;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;

namespace Micropack.AspNetCore.RedisCache
{
    public interface IResponseCacheService
    {
        Task<string> GetCachedResponseAsync(string cacheKey);

        Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeToLive);
    }

    public class ResponseCacheService : IResponseCacheService, ISingletonDependency
    {
        private readonly IDistributedCache _distributedCache;

        public ResponseCacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task<string> GetCachedResponseAsync(string cacheKey)
        {
            var cachedResponse = await _distributedCache.GetStringAsync(cacheKey);
            return string.IsNullOrWhiteSpace(cachedResponse) ? null : cachedResponse;
        }

        public async Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeToLive)
        {
            if (response == null) return;
            var serializedResponse = JsonConvert.SerializeObject(response);
            await _distributedCache.SetStringAsync(cacheKey, serializedResponse, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = timeToLive
            });
        }
    }
}

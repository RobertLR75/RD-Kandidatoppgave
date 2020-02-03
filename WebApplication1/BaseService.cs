using System;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Repository.Abstractions;
using ServiceStack.Data;

namespace Service
{
    public class BaseService : ServiceStack.Service
    {
        
        protected ILogger<BaseService> Logger;
        protected new IMemoryCache Cache;
        public BaseService(ILogger<BaseService> logger, IMemoryCache memoryCache )
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            Cache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        }

        protected TItem GetCache<TItem>(CacheModuleKey module, string key)
        {
            return (TItem)(Cache.TryGetValue(module + key, out var cacheEntry) ? cacheEntry : null);
        }

        protected void AddCache<TItem>(TItem value, CacheModuleKey module, string key)
        {
            if (!Cache.TryGetValue(module + key, out var cacheEntry))
            {
                cacheEntry = value;

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(3));

                Cache.Set(module + key, cacheEntry);
            }

        }

        protected void RemoveCache(CacheModuleKey module, string key)
        {
            Cache.Remove(module + key);
        }

    }
}

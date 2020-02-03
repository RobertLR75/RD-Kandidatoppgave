using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Caching.Memory;

namespace Service
{
    public class MemCache : IMemoryCache
    {
        private readonly IMemoryCache _cache;

        public MemCache()
        {
            var options = new MemoryCacheOptions();

            _cache = new MemoryCache(options);

        }

        public void Dispose()
        {
            _cache.Dispose();
        }

        public bool TryGetValue(object key, out object value)
        {
            return _cache.TryGetValue(key, out value);


        }

        public ICacheEntry CreateEntry(object key)
        {
            return _cache.CreateEntry(key);
        }

        public void Remove(object key)
        {
            _cache.Remove(key);
        }

        public void Set(string key, object value)
        {
            _cache.Set(key, value);
        }
    }

    public enum CacheModuleKey
    {
        Tenant = 0,
        Client = 1,
        User = 2,
        Role = 3,
        Permission = 4,
        SourceSystem = 5,
        Service = 6,
        Product = 7

    }


}

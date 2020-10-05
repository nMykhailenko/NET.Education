using Authentication.Services.Contract;
using Authentication.Settings;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Services
{
    public class CacheService<T> : ICacheService<T> where T : class, new ()
    {
        private readonly IMemoryCache _memoryCache;
        public CacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }


        public void SetValue(object key, T value)
        {
            _memoryCache.Set(key, value);
        }

        public T TryGetValue(object key)
        {
            if (_memoryCache.TryGetValue<T>(key, out T value)) return value;

            return null;
        }
    }
}

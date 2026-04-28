using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Topic.Performance.Caching.DistributedCache.Redis.RedisPlaygroundRefProj
{
    internal class MemoryCacheService : ICacheService
    {
        private readonly Dictionary<string, object> _store = new();

        public Task<T?> GetAsync<T>(string key)
        {
            if (_store.TryGetValue(key, out var value))
                return Task.FromResult((T?)value);

            return Task.FromResult(default(T));
        }

        public Task SetAsync<T>(string key, T value, TimeSpan expiry)
        {
            _store[key] = value;

            // NOTE: expiry not implemented here (important gap)
            return Task.CompletedTask;
        }
    }
}
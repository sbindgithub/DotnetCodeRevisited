using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Topic.Performance.Caching.DistributedCache.Redis.RedisPlaygroundRefProj
{
    internal class RedisCacheService : ICacheService
    {
        public Task<T?> GetAsync<T>(string key)
        {
            // Imagine:
            // 1. Network call to Redis
            // 2. Get string value
            // 3. Deserialize

            return Task.FromResult(default(T));
        }

        public Task SetAsync<T>(string key, T value, TimeSpan expiry)
        {
            // Imagine:
            // 1. Serialize object → JSON
            // 2. Send to Redis
            // 3. Apply TTL

            return Task.CompletedTask;
        }
    }
}
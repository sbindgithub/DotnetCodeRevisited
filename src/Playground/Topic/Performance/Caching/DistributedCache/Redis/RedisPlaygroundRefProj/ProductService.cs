using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Topic.Performance.Caching.DistributedCache.Redis.RedisPlaygroundRefProj
{
    public class ProductService
    {
        private readonly ICacheService _cache;

        public ProductService(ICacheService cache)
        {
            _cache = cache;
        }

        public async Task<Product> GetProduct(int id)
        {
            var key = $"product:{id}";

            var cached = await _cache.GetAsync<Product>(key);

            if (cached != null)
                return cached;

            // Simulate DB call
            var product = new Product { Id = id, Name = "Sample" };

            await _cache.SetAsync(key, product, TimeSpan.FromMinutes(5));

            return product;
        }
    }
}

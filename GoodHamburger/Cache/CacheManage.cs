using GoodHamburger.Infrastructure.Data.Contexts;
using Microsoft.Extensions.Caching.Memory;

namespace GoodHamburger.Api.Cache
{
    public static class CacheManage
    {

        private static readonly IMemoryCache _memoryCache = new MemoryCache(new MemoryCacheOptions());


        public static void setCacheDataContext(MockDataContext obj, string key)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(60))
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
                .SetPriority(CacheItemPriority.Normal)
                .SetSize(1024);

            _memoryCache.Set(key, obj, cacheEntryOptions);
        }

        public static MockDataContext getCacheDataContext(String key)
        {
            MockDataContext mockData= new MockDataContext();
            _memoryCache.TryGetValue(key, out mockData);

            return mockData;
        }
    }
}

using laget.Caching.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;

namespace laget.Caching.Extensions
{
    public static class CacheExtensions
    {
        public static TItem Get<TItem>(this ICache cache, object key)
        {
            return cache.Get<TItem>(key);
        }

        public static async Task<TItem> GetAsync<TItem>(this ICache cache, object key)
        {
            return await cache.GetAsync<TItem>(key);
        }

        public static void Set<TItem>(this ICache cache, object key, object item)
        {
            cache.Set<TItem>(key, item);
        }

        public static async Task SetAsync<TItem>(this ICache cache, object key, object item)
        {
            await cache.SetAsync<TItem>(key, item);
        }

        public static void Set<TItem>(this ICache cache, object key, object item, MemoryCacheEntryOptions options)
        {
            Set<TItem>(cache, key, item, options);
        }

        public static async Task SetAsync<TItem>(this ICache cache, object key, object item, MemoryCacheEntryOptions options)
        {
            await cache.SetAsync<TItem>(key, item, options);
        }

        public static TItem GetOrSet<TItem>(this ICache cache, object key, object item)
        {
            return cache.GetOrSet<TItem>(key, item);
        }

        public static async Task<TItem> GetOrSetAsync<TItem>(this ICache cache, object key, object item)
        {
            return await cache.GetOrSetAsync<TItem>(key, item);
        }

        public static TItem GetOrSet<TItem>(this ICache cache, object key, object item, MemoryCacheEntryOptions options)
        {
            return cache.GetOrSet<TItem>(key, item, options);
        }

        public static async Task<TItem> GetOrSetAsync<TItem>(this ICache cache, object key, object item, MemoryCacheEntryOptions options)
        {
            return await cache.GetOrSetAsync<TItem>(key, item, options);
        }

        public static void Remove<TItem>(this ICache cache, object key)
        {
            cache.Remove<TItem>(key);
        }

        public static async Task RemoveAsync<TItem>(this ICache cache, object key)
        {
            await cache.RemoveAsync<TItem>(key);
        }

        public static void Clear<TItem>(this ICache cache)
        {
            cache.Clear<TItem>();
        }

        public static async Task ClearAsync<TItem>(this ICache cache)
        {
            await cache.ClearAsync<TItem>();
        }

        public static bool Contains<TItem>(this ICache cache, object key)
        {
            return cache.Contains<TItem>(key);
        }

        public static async Task<bool> ContainsAsync<TItem>(this ICache cache, object key)
        {
            return await cache.ContainsAsync<TItem>(key);
        }

        public static bool IsEmpty<TItem>(this ICache cache)
        {
            return cache.IsEmpty<TItem>();
        }

        public static async Task<bool> IsEmptyAsync<TItem>(this ICache cache)
        {
            return await cache.IsEmptyAsync<TItem>();
        }
    }
}

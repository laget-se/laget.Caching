using System.Threading.Tasks;
using laget.Caching.Interfaces;
using laget.Caching.Options;
using Microsoft.Extensions.Caching.Memory;

namespace laget.Caching
{
    public class Cache : ICache
    {
        private readonly MemoryCache _cache;
        private readonly CacheOptions _options;

        public Cache()
        {
            _options = new CacheOptions();
            _cache = new MemoryCache(_options.MemoryCacheOptions);
        }

        public Cache(CacheOptions options)
        {
            _options = options;
            _cache = new MemoryCache(options.MemoryCacheOptions);
        }

        public TItem Get<TItem>(object key)
        {
            if (!string.IsNullOrWhiteSpace(_options.KeyPrefix))
                key = $"{_options.KeyPrefix}_{key}";

            _cache.TryGetValue(key, out TItem item);
            return item;
        }

        public async Task<TItem> GetAsync<TItem>(object key)
        {
            return await Task.Run(() => Get<TItem>(key));
        }

        public TItem Set<TItem>(object key, object item)
        {
            if (!string.IsNullOrWhiteSpace(_options.KeyPrefix))
                key = $"{_options.KeyPrefix}_{key}";

            return (TItem)_cache.Set(key, item);
        }

        public async Task<TItem> SetAsync<TItem>(object key, object item)
        {
            return await Task.Run(() => Set<TItem>(key, item));
        }

        public TItem Set<TItem>(object key, object item, MemoryCacheEntryOptions options)
        {
            if (!string.IsNullOrWhiteSpace(_options.KeyPrefix))
                key = $"{_options.KeyPrefix}_{key}";

            return (TItem)_cache.Set(key, item, options);
        }

        public async Task<TItem> SetAsync<TItem>(object key, object item, MemoryCacheEntryOptions options)
        {
            return await Task.Run(() => Set<TItem>(key, item, options));
        }

        public TItem GetOrSet<TItem>(object key, object item)
        {
            if (!string.IsNullOrWhiteSpace(_options.KeyPrefix))
                key = $"{_options.KeyPrefix}_{key}";

            return (TItem)_cache.GetOrCreate(key, entry =>
            {
                entry.SetValue(item);
                return entry.Value;
            });
        }

        public async Task<TItem> GetOrSetAsync<TItem>(object key, object item)
        {
            return await Task.Run(() => GetOrSet<TItem>(key, item));
        }

        public TItem GetOrSet<TItem>(object key, object item, MemoryCacheEntryOptions options)
        {
            if (!string.IsNullOrWhiteSpace(_options.KeyPrefix))
                key = $"{_options.KeyPrefix}_{key}";

            return (TItem)_cache.GetOrCreate(key, entry =>
            {
                entry.SetValue(item);
                entry.SetOptions(options);
                return entry.Value;
            });
        }

        public async Task<TItem> GetOrSetAsync<TItem>(object key, object item, MemoryCacheEntryOptions options)
        {
            return await Task.Run(() => GetOrSet<TItem>(key, item, options));
        }

        public void Remove<TItem>(object key)
        {
            if (!string.IsNullOrWhiteSpace(_options.KeyPrefix))
                key = $"{_options.KeyPrefix}_{key}";

            _cache.Remove(key);
        }

        public async Task RemoveAsync<TItem>(object key)
        {
            await Task.Run(() => Remove<TItem>(key));
        }

        public void Clear<TItem>()
        {
            _cache.Dispose();
        }

        public async Task ClearAsync<TItem>()
        {
            await Task.Run(Clear<TItem>);
        }

        public bool Contains<TItem>(object key)
        {
            if (!string.IsNullOrWhiteSpace(_options.KeyPrefix))
                key = $"{_options.KeyPrefix}_{key}";

            return _cache.TryGetValue(key, out _);
        }

        public async Task<bool> ContainsAsync<TItem>(object key)
        {
            return await Task.Run(() => Contains<TItem>(key));
        }

        public int Count()
        {
            return _cache.Count;
        }

        public async Task<int> CountAsync()
        {
            return await Task.Run(Count);
        }

        public bool IsEmpty<TItem>()
        {
            return _cache.Count == 0;
        }

        public async Task<bool> IsEmptyAsync<TItem>()
        {
            return await Task.Run(IsEmpty<TItem>);
        }
    }

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
            cache.Set<TItem>(key, item, options);
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

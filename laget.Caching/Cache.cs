using System;
using System.Threading.Tasks;
using laget.Caching.Interfaces;
using laget.Caching.Options;
using Microsoft.Extensions.Caching.Memory;

namespace laget.Caching
{
    public class Cache : ICache
    {
        protected readonly MemoryCache Entries;
        protected readonly CacheOptions Options;

        public Cache()
        {
            Options = new CacheOptions();
            Entries = new MemoryCache(Options.MemoryCacheOptions);
        }

        public Cache(CacheOptions options)
        {
            Options = options;
            Entries = new MemoryCache(options.MemoryCacheOptions);
        }

        public virtual TItem Get<TItem>(IKey key)
        {
            ValidateCacheKey(key);

            Entries.TryGetValue(key.ToString(), out TItem item);
            return item;
        }

        public virtual async Task<TItem> GetAsync<TItem>(IKey key)
        {
            return await Task.Run(() => Get<TItem>(key));
        }

        public virtual TItem Set<TItem>(IKey key, object item)
        {
            ValidateCacheKey(key);

            return (TItem)Entries.Set(key.ToString(), item);
        }

        public virtual async Task<TItem> SetAsync<TItem>(IKey key, object item)
        {
            return await Task.Run(() => Set<TItem>(key, item));
        }

        public virtual TItem Set<TItem>(IKey key, object item, MemoryCacheEntryOptions options)
        {
            ValidateCacheKey(key);

            return (TItem)Entries.Set(key.ToString(), item, options);
        }

        public virtual async Task<TItem> SetAsync<TItem>(IKey key, object item, MemoryCacheEntryOptions options)
        {
            return await Task.Run(() => Set<TItem>(key, item, options));
        }

        public virtual TItem GetOrSet<TItem>(IKey key, object item)
        {
            ValidateCacheKey(key);

            return (TItem)Entries.GetOrCreate(key.ToString(), entry =>
            {
                entry.SetValue(item);
                return entry.Value;
            });
        }

        public virtual async Task<TItem> GetOrSetAsync<TItem>(IKey key, object item)
        {
            return await Task.Run(() => GetOrSet<TItem>(key, item));
        }

        public TItem GetOrSet<TItem>(IKey key, Func<TItem> factory)
        {
            ValidateCacheKey(key);

            return Entries.GetOrCreate<TItem>(key.ToString(), entry => factory());
        }

        public async Task<TItem> GetOrSetAsync<TItem>(IKey key, Func<TItem> factory)
        {
            return await Task.Run(() => GetOrSet<TItem>(key, factory));
        }

        public virtual TItem GetOrSet<TItem>(IKey key, object item, MemoryCacheEntryOptions options)
        {
            ValidateCacheKey(key);

            return (TItem)Entries.GetOrCreate(key.ToString(), entry =>
            {
                entry.SetValue(item);
                entry.SetOptions(options);
                return entry.Value;
            });
        }

        public virtual async Task<TItem> GetOrSetAsync<TItem>(IKey key, object item, MemoryCacheEntryOptions options)
        {
            return await Task.Run(() => GetOrSet<TItem>(key, item, options));
        }

        public virtual void Remove<TItem>(IKey key)
        {
            ValidateCacheKey(key);

            Entries.Remove(key.ToString());
        }

        public virtual async Task RemoveAsync<TItem>(IKey key)
        {
            await Task.Run(() => Remove<TItem>(key));
        }

        public virtual void Clear<TItem>()
        {
            Entries.Dispose();
        }

        public virtual async Task ClearAsync<TItem>()
        {
            await Task.Run(Clear<TItem>);
        }

        public virtual bool Contains<TItem>(IKey key)
        {
            ValidateCacheKey(key);

            return Entries.TryGetValue(key.ToString(), out _);
        }

        public virtual async Task<bool> ContainsAsync<TItem>(IKey key)
        {
            return await Task.Run(() => Contains<TItem>(key));
        }

        public virtual int Count()
        {
            return Entries.Count;
        }

        public virtual async Task<int> CountAsync()
        {
            return await Task.Run(Count);
        }

        public virtual bool IsEmpty<TItem>()
        {
            return Entries.Count == 0;
        }

        public virtual async Task<bool> IsEmptyAsync<TItem>()
        {
            return await Task.Run(IsEmpty<TItem>);
        }


        private static void ValidateCacheKey(IKey key)
        {
            if (key == null || string.IsNullOrWhiteSpace(key.ToString()))
                throw new ArgumentNullException(nameof(key));
        }
    }
}

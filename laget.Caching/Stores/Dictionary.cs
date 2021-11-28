using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using laget.Caching.Interfaces;

namespace laget.Caching.Stores
{
    public class Dictionary<TKey> : ICache
    {
        protected readonly ConcurrentDictionary<string, object> Entries;

        public Dictionary()
        {
            Entries = new ConcurrentDictionary<string, object>();
        }

        public virtual TItem Get<TItem>(IKey key)
        {
            ValidateCacheKey(key);

            Entries.TryGetValue(key.ToString(), out var item);
            return (TItem)item;
        }

        public virtual async Task<TItem> GetAsync<TItem>(IKey key)
        {
            return await Task.Run(() => Get<TItem>(key));
        }

        public virtual TItem Set<TItem>(IKey key, object item)
        {
            ValidateCacheKey(key);

            return (TItem)Entries.GetOrAdd(key.ToString(), item);
        }

        public virtual async Task<TItem> SetAsync<TItem>(IKey key, object item)
        {
            return await Task.Run(() => Set<TItem>(key, item));
        }

        public virtual TItem GetOrSet<TItem>(IKey key, object item)
        {
            ValidateCacheKey(key);

            return (TItem)Entries.GetOrAdd(key.ToString(), item);
        }

        public virtual async Task<TItem> GetOrSetAsync<TItem>(IKey key, object item)
        {
            return await Task.Run(() => GetOrSet<TItem>(key, item));
        }

        public virtual TItem GetOrSet<TItem>(IKey key, Func<TItem> factory)
        {
            ValidateCacheKey(key);

            return (TItem)Entries.GetOrAdd(key.ToString(), entry => factory());
        }

        public virtual async Task<TItem> GetOrSetAsync<TItem>(IKey key, Func<TItem> factory)
        {
            return await Task.Run(() => GetOrSet<TItem>(key, factory));
        }

        public virtual void Remove<TItem>(IKey key)
        {
            ValidateCacheKey(key);

            Entries.TryRemove(key.ToString(), out _);
        }

        public virtual async Task RemoveAsync<TItem>(IKey key)
        {
            await Task.Run(() => Remove<TItem>(key));
        }

        public virtual void Clear<TItem>()
        {
            Entries.Clear();
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

            if (key.GetType() != typeof(TKey))
                throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}

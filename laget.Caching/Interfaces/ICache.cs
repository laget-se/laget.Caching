using System;
using System.Threading.Tasks;

namespace laget.Caching.Interfaces
{
    public interface ICache
    {
        TItem Get<TItem>(IKey key);
        Task<TItem> GetAsync<TItem>(IKey key);

        TItem Set<TItem>(IKey key, object item);
        Task<TItem> SetAsync<TItem>(IKey key, object item);

        TItem GetOrSet<TItem>(IKey key, object item);
        Task<TItem> GetOrSetAsync<TItem>(IKey key, object item);
        TItem GetOrSet<TItem>(IKey key, Func<TItem> factory);
        Task<TItem> GetOrSetAsync<TItem>(IKey key, Func<TItem> factory);

        void Remove<TItem>(IKey key);
        Task RemoveAsync<TItem>(IKey key);

        void Clear<TItem>();
        Task ClearAsync<TItem>();

        int Count();
        Task<int> CountAsync();

        bool Contains<TItem>(IKey key);
        Task<bool> ContainsAsync<TItem>(IKey key);

        bool IsEmpty<TItem>();
        Task<bool> IsEmptyAsync<TItem>();
    }
}

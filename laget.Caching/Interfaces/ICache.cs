using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace laget.Caching.Interfaces
{
    public interface ICache
    {
        TItem Get<TItem>(object key);
        Task<TItem> GetAsync<TItem>(object key);

        TItem Set<TItem>(object key, object item);
        Task<TItem> SetAsync<TItem>(object key, object item);
        TItem Set<TItem>(object key, object item, MemoryCacheEntryOptions options);
        Task<TItem> SetAsync<TItem>(object key, object item, MemoryCacheEntryOptions options);

        TItem GetOrSet<TItem>(object key, object item);
        Task<TItem> GetOrSetAsync<TItem>(object key, object item);
        TItem GetOrSet<TItem>(object key, object item, MemoryCacheEntryOptions options);
        Task<TItem> GetOrSetAsync<TItem>(object key, object item, MemoryCacheEntryOptions options);

        void Remove<TItem>(object key);
        Task RemoveAsync<TItem>(object key);

        void Clear<TItem>();
        Task ClearAsync<TItem>();

        int Count();
        Task<int> CountAsync(); 

        bool Contains<TItem>(object key);
        Task<bool> ContainsAsync<TItem>(object key);

        bool IsEmpty<TItem>();
        Task<bool> IsEmptyAsync<TItem>();
    }
}

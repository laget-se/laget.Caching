using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace laget.Caching.Interfaces
{
    public interface IMemoryCache : ICache
    {
        TItem Set<TItem>(IKey key, object item, MemoryCacheEntryOptions options);
        Task<TItem> SetAsync<TItem>(IKey key, object item, MemoryCacheEntryOptions options);

        TItem GetOrSet<TItem>(IKey key, object item, MemoryCacheEntryOptions options);
        Task<TItem> GetOrSetAsync<TItem>(IKey key, object item, MemoryCacheEntryOptions options);
        TItem GetOrSet<TItem>(IKey key, Func<TItem> factory, MemoryCacheEntryOptions options);
        Task<TItem> GetOrSetAsync<TItem>(IKey key, Func<TItem> factory, MemoryCacheEntryOptions options);
    }
}

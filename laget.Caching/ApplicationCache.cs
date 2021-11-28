using laget.Caching.Keys;
using laget.Caching.Stores;
using Microsoft.Extensions.Caching.Memory;

namespace laget.Caching
{
    public interface IApplicationCache : Interfaces.IMemoryCache
    {
    }

    public class ApplicationCache : Memory<ApplicationKey>, IApplicationCache
    {
        public ApplicationCache()
        {
        }

        public ApplicationCache(MemoryCacheOptions options)
            : base(options)
        {
        }
    }
}

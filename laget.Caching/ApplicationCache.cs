using laget.Caching.Interfaces;
using laget.Caching.Options;

namespace laget.Caching
{
    public interface IApplicationCache : ICache
    {
    }

    public class ApplicationCache : Cache, IApplicationCache
    {
        public ApplicationCache()
            : base()
        {
        }

        public ApplicationCache(CacheOptions options)
            : base(options)
        {
        }
    }
}

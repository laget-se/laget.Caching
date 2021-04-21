using laget.Caching.Interfaces;
using laget.Caching.Keys;
using laget.Caching.Options;

namespace laget.Caching
{
    public interface IRequestCache
    {
    }

    public class RequestCache : Cache, IApplicationCache
    {
        public RequestCache()
            : base()
        {
        }

        public RequestCache(CacheOptions options)
            : base(options)
        {
        }
    }
}

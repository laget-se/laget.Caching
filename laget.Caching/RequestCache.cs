using laget.Caching.Interfaces;
using laget.Caching.Options;

namespace laget.Caching
{
    public interface IRequestCache : ICache
    {
    }

    public class RequestCache : Cache, IRequestCache
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

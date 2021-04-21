using laget.Caching.Interfaces;
using laget.Caching.Options;

namespace laget.Caching
{
    public interface ISessionCache : ICache
    {
    }

    public class SessionCache : Cache, ISessionCache
    {
        public SessionCache()
            : base()
        {
        }

        public SessionCache(CacheOptions options)
            : base(options)
        {
        }
    }
}

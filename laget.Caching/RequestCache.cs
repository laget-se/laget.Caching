using laget.Caching.Interfaces;
using laget.Caching.Keys;
using laget.Caching.Stores;

namespace laget.Caching
{
    public interface IRequestCache : ICache
    {
    }

    public class RequestCache : Dictionary<RequestKey>, IRequestCache
    {
        public RequestCache()
            : base()
        {
        }
    }
}

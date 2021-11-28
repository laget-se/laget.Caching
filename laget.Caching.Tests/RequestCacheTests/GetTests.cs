using laget.Caching.Keys;
using Xunit;

namespace laget.Caching.Tests.RequestCacheTests
{
    public class GetTests
    {
        private static IRequestCache CreateCache()
        {
            return new RequestCache();
        }

        [Fact]
        public void GetMissingKeyReturnsNull()
        {
            var cache = CreateCache();
            var key = new RequestKey(typeof(object), "key");

            var result = cache.Get<object>(key);
            Assert.Null(result);
        }
    }
}

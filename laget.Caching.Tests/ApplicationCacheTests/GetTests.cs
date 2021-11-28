using laget.Caching.Keys;
using Xunit;

namespace laget.Caching.Tests.ApplicationCacheTests
{
    public class GetTests
    {
        private static IApplicationCache CreateCache()
        {
            return new ApplicationCache();
        }


        [Fact]
        public void GetMissingKeyReturnsNull()
        {
            var cache = CreateCache();
            var key = new ApplicationKey(typeof(object), "key");

            var result = cache.Get<object>(key);
            Assert.Null(result);
        }
    }
}

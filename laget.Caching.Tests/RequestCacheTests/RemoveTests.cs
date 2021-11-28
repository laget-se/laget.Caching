using laget.Caching.Keys;
using Xunit;

namespace laget.Caching.Tests.RequestCacheTests
{
    public class RemoveTests
    {
        private static IRequestCache CreateCache()
        {
            return new RequestCache();
        }

        [Fact]
        public void RemoveRemoves()
        {
            var cache = CreateCache();
            var obj = new object();
            var key = new RequestKey(typeof(object), "key");

            var result = cache.Set<object>(key, obj);
            Assert.Same(obj, result);

            cache.Remove<object>(key);
            result = cache.Get<object>(key);
            Assert.Null(result);
        }
    }
}

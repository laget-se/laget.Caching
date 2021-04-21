using laget.Caching.Keys;
using Xunit;

namespace laget.Caching.Tests
{
    public class RemoveTests
    {
        private static IApplicationCache CreateCache()
        {
            return new ApplicationCache();
        }

        [Fact]
        public void RemoveRemoves()
        {
            var cache = CreateCache();
            var obj = new object();
            var key = new ApplicationKey("key");

            var result = cache.Set<object>(key, obj);
            Assert.Same(obj, result);

            cache.Remove<object>(key);
            result = cache.Get<object>(key);
            Assert.Null(result);
        }
    }
}

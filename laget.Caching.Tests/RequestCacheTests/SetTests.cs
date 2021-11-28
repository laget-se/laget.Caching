using System;
using laget.Caching.Keys;
using Xunit;

namespace laget.Caching.Tests.RequestCacheTests
{
    public class SetTests
    {
        private static IRequestCache CreateCache()
        {
            return new RequestCache();
        }

        [Fact]
        public void ShouldNotLeakBetweenInstances()
        {
            var cache1 = CreateCache();
            var cache2 = CreateCache();

            var key = new RequestKey(typeof(object), "key");

            var result1 = cache1.GetOrSet(key, () => new { name = "first" });
            var result2 = cache2.GetOrSet(key, () => new { name = "first" });

            Assert.NotSame(result1, result2);
            Assert.Equal(1, cache1.Count());
            Assert.Equal(1, cache2.Count());
        }

        [Fact]
        public void SetAlwaysOverwrites()
        {
            var cache = CreateCache();
            var obj = new object();
            var key = new RequestKey(typeof(object), "key");

            var result = cache.Set<object>(key, obj);
            Assert.Same(obj, result);

            result = cache.Get<object>(new RequestKey(typeof(object), "key"));
            Assert.Same(obj, result);
        }

        [Fact]
        public void SetDataToCacheWithNullKeyThrowsException()
        {
            var cache = CreateCache();
            var value = new object();
            Assert.Throws<ArgumentNullException>(() => cache.Set<object>(null, value));
        }

        [Fact]
        public void SetDataToCacheWithEmptyKeyThrowsException()
        {
            var cache = CreateCache();
            Assert.Throws<ArgumentNullException>(() => new RequestKey(typeof(object), ""));
        }
    }
}

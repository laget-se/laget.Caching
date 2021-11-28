using System;
using laget.Caching.Keys;
using Xunit;

namespace laget.Caching.Tests.ApplicationCacheTests
{
    public class SetTests
    {
        private static IApplicationCache CreateCache()
        {
            return new ApplicationCache();
        }

        [Fact]
        public void SetAlwaysOverwrites()
        {
            var cache = CreateCache();
            var obj = new object();
            var key = new ApplicationKey(typeof(object), "key");

            var result = cache.Set<object>(key, obj);
            Assert.Same(obj, result);

            var obj2 = new object();
            result = cache.Set<object>(key, obj2);
            Assert.Same(obj2, result);

            result = cache.Get<object>(new ApplicationKey(typeof(object), "key"));
            Assert.Same(obj2, result);
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
            Assert.Throws<ArgumentNullException>(() => new ApplicationKey(typeof(object), ""));
        }
    }
}

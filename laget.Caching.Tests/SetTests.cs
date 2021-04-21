using System;
using laget.Caching.Keys;
using Xunit;

namespace laget.Caching.Tests
{
    public class SetTests
    {
        private static IApplicationCache CreateCache()
        {
            return new ApplicationCache();
        }

        [Fact]
        public void GetMissingKeyReturnsNull()
        {
            var cache = CreateCache();
            var key = new ApplicationKey("key");

            var result = cache.Get<object>(key);
            Assert.Null(result);
        }

        [Fact]
        public void SetAlwaysOverwrites()
        {
            var cache = CreateCache();
            var obj = new object();
            var key = new ApplicationKey("key");

            var result = cache.Set<object>(key, obj);
            Assert.Same(obj, result);

            var obj2 = new object();
            result = cache.Set<object>(key, obj2);
            Assert.Same(obj2, result);

            result = cache.Get<object>(new ApplicationKey("key"));
            Assert.Same(obj2, result);
        }

        [Fact]
        public void SetDataToCacheWithNullKeyThrows()
        {
            var cache = CreateCache();
            var value = new object();
            Assert.Throws<ArgumentNullException>(() => cache.Set<object>(null, value));
        }

        [Fact]
        public void SetDataToCacheWithEmptyKeyThrows()
        {
            var cache = CreateCache();
            var key = new ApplicationKey("");
            var value = new object();
            Assert.Throws<ArgumentNullException>(() => cache.Set<object>(key, value));
        }
    }
}

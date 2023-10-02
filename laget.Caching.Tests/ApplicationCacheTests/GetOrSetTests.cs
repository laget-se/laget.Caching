using laget.Caching.Keys;
using System;
using System.Threading.Tasks;
using Xunit;

namespace laget.Caching.Tests.ApplicationCacheTests
{
    public class GetOrSetTests
    {
        private static IApplicationCache CreateCache()
        {
            return new ApplicationCache();
        }

        [Fact]
        public void GetOrSetReturnsObject()
        {
            var cache = CreateCache();
            var obj = new object();
            var key = new ApplicationKey(typeof(object), "key");

            var result = cache.GetOrSet<object>(key, obj);
            Assert.Same(obj, result);

            result = cache.Get<object>(key);
            Assert.Same(obj, result);
        }

        [Fact]
        public void GetOrSetWorksWithCaseSensitiveKeys()
        {
            var cache = CreateCache();
            var obj = new object();
            var key1 = new ApplicationKey(typeof(object), "key");
            var key2 = new ApplicationKey(typeof(object), "Key");

            var result = cache.GetOrSet<object>(key1, obj);
            Assert.Same(obj, result);

            result = cache.Get<object>(key1);
            Assert.Same(obj, result);

            result = cache.Get<object>(key2);
            Assert.Null(result);
        }

        [Fact]
        public void GetOrSet_AddsNewValue()
        {
            var cache = CreateCache();
            var obj = new object();
            var key = new ApplicationKey(typeof(object), "key");

            var result = cache.GetOrSet<object>(key, obj);

            Assert.Same(obj, result);

            result = cache.Get<object>(key);
            Assert.Same(obj, result);
        }

        [Fact]
        public async Task GetOrSetAsync_AddsNewValue()
        {
            var cache = CreateCache();
            var obj = new object();
            var key = new ApplicationKey(typeof(object), "key");

            var result = await cache.GetOrSetAsync<object>(key, obj);

            Assert.Same(obj, result);

            result = cache.Get<object>(key);
            Assert.Same(obj, result);
        }

        [Fact]
        public void GetOrCreate_ReturnExistingValue()
        {
            var cache = CreateCache();
            var obj = new object();
            var key = new ApplicationKey(typeof(object), "key");
            var invoked = false;

            cache.Set<object>(key, obj);

            var result = cache.GetOrSet<object>(key, obj);

            Assert.False(invoked);
            Assert.Same(obj, result);
        }

        [Fact]
        public async Task GetOrSetAsync_ReturnExistingValue()
        {
            var cache = CreateCache();
            var obj = new object();
            var key = new ApplicationKey(typeof(object), "key");

            cache.Set<object>(key, obj);

            var result = await cache.GetOrSetAsync<object>(key, obj);

            Assert.Same(obj, result);
        }

        [Fact]
        public void GetDataFromCacheWithNullKeyThrowsException()
        {
            var cache = CreateCache();
            Assert.Throws<ArgumentNullException>(() => cache.Get<object>(null));
        }

        [Fact]
        public void GetOrSetFromCacheWithNullKeyThrowsException()
        {
            var cache = CreateCache();
            Assert.Throws<ArgumentNullException>(() => cache.GetOrSet<object>(null, null));
        }

        [Fact]
        public async Task GetOrCreateAsyncFromCacheWithNullKeyThrowsException()
        {
            var cache = CreateCache();
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await cache.GetOrSetAsync<object>(null, null));
        }
    }
}

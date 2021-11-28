using System;
using laget.Caching.Keys;
using Xunit;

namespace laget.Caching.Tests.RequestCacheTests
{
    public class KeyTests
    {
        [Fact]
        public void ShouldCreateRequestKey()
        {
            var key = new RequestKey(typeof(string), "key");

            Assert.Equal("string", key.Type);
            Assert.Equal("key", key.Key);
        }

        [Fact]
        public void ShouldThrowExceptionForInvalidRequestKey()
        {
            Assert.Throws<ArgumentNullException>(() => new RequestKey(null, ""));
        }
    }
}

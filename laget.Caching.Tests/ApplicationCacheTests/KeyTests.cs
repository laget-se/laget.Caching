using System;
using laget.Caching.Keys;
using Xunit;

namespace laget.Caching.Tests.ApplicationCacheTests
{
    public class KeyTests
    {
        [Fact]
        public void ShouldCreateApplicationKey()
        {
            var key = new ApplicationKey(typeof(string), "key");

            Assert.Equal("string", key.Type);
            Assert.Equal("key", key.Key);
        }

        [Fact]
        public void ShouldThrowExceptionForInvalidApplicationKey()
        {
            Assert.Throws<ArgumentNullException>(() => new ApplicationKey(null, ""));
        }
    }
}

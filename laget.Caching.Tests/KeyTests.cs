using System;
using laget.Caching.Keys;
using Xunit;

namespace laget.Caching.Tests
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

        [Fact]
        public void ShouldCreateSessionKey()
        {
            var key = new SessionKey(typeof(string), "session", "key");

            Assert.Equal("string", key.Type);
            Assert.Equal("key", key.Key);
            Assert.Equal("session", key.Session);
        }

        [Fact]
        public void ShouldThrowExceptionForInvalidSessionKey()
        {
            Assert.Throws<ArgumentNullException>(() => new SessionKey(null, "", ""));
        }
    }
}

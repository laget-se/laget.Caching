﻿using System;
using System.Threading;
using System.Threading.Tasks;
using laget.Caching.Options;
using Microsoft.Extensions.Caching.Memory;
using Xunit;

namespace laget.Caching.Tests
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
            var key = "myKey";

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
            var key1 = "myKey";
            var key2 = "Mykey";

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
            var key = "myKey";

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
            var key = "myKey";

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
            var key = "myKey";
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
            var key = "myKey";

            cache.Set<object>(key, obj);

            var result = await cache.GetOrSetAsync<object>(key, obj);

            Assert.Same(obj, result);
        }

        [Fact]
        public void AddAndReplaceEntries_AreThreadSafe()
        {
            var cache = new ApplicationCache(
                new CacheOptions
                {
                    MemoryCacheOptions = new MemoryCacheOptions
                    {
                        ExpirationScanFrequency = TimeSpan.Zero,
                        SizeLimit = 20,
                        CompactionPercentage = 0.5
                    }
                });
            var cts = new CancellationTokenSource();

            var random = new Random();

            var task0 = Task.Run(() =>
            {
                while (!cts.IsCancellationRequested)
                {
                    var entrySize = random.Next(0, 5);
                    cache.Set<object>(random.Next(0, 10), entrySize, new MemoryCacheEntryOptions { Size = entrySize });
                }
            });

            var task1 = Task.Run(() =>
            {
                while (!cts.IsCancellationRequested)
                {
                    var entrySize = random.Next(0, 5);
                    cache.Set<object>(random.Next(0, 10), entrySize, new MemoryCacheEntryOptions { Size = entrySize });
                }
            });

            var task2 = Task.Run(() =>
            {
                while (!cts.IsCancellationRequested)
                {
                    var entrySize = random.Next(0, 5);
                    cache.Set<object>(random.Next(0, 10), entrySize, new MemoryCacheEntryOptions { Size = entrySize });
                }
            });

            cts.CancelAfter(TimeSpan.FromSeconds(5));
            var task3 = Task.Delay(TimeSpan.FromSeconds(7));

            Task.WaitAll(task0, task1, task2, task3);

            Assert.Equal(TaskStatus.RanToCompletion, task0.Status);
            Assert.Equal(TaskStatus.RanToCompletion, task1.Status);
            Assert.Equal(TaskStatus.RanToCompletion, task2.Status);
            Assert.Equal(TaskStatus.RanToCompletion, task3.Status);

            //var cacheSize = 0;
            //for (var i = 0; i < 10; i++)
            //{
            //    cacheSize += cache.Get<int>(i);
            //}

            //Assert.Equal(cacheSize, cache.Size);
            Assert.InRange(cache.Count(), 0, 20);
        }

        [Fact]
        public void GetDataFromCacheWithNullKeyThrows()
        {
            var cache = CreateCache();
            Assert.Throws<ArgumentNullException>(() => cache.Get<object>(null));
        }

        [Fact]
        public void GetOrSetFromCacheWithNullKeyThrows()
        {
            var cache = CreateCache();
            Assert.Throws<ArgumentNullException>(() => cache.GetOrSet<object>(null, null));
        }

        [Fact]
        public async Task GetOrCreateAsyncFromCacheWithNullKeyThrows()
        {
            var cache = CreateCache();
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await cache.GetOrSetAsync<object>(null, null));
        }
    }
}

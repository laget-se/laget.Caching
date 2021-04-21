using Microsoft.Extensions.Caching.Memory;

namespace laget.Caching.Options
{
    public class CacheOptions
    {
        public MemoryCacheOptions MemoryCacheOptions { get; set; } = new MemoryCacheOptions();
        public string KeyPrefix { get; set; }
    }
}

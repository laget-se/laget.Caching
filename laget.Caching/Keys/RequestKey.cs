using System;
using laget.Caching.Interfaces;

namespace laget.Caching.Keys
{
    public class RequestKey : IKey
    {
        public string Type { get; }
        public string Key { get; }

        public RequestKey(Type type, string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));

            Type = type.Name.ToLowerInvariant();
            Key = key;
        }

        public override string ToString()
        {
            return $"{Type}.{Key}";
        }
    }
}

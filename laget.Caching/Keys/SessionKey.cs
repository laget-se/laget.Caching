using System;
using laget.Caching.Interfaces;

namespace laget.Caching.Keys
{
    public class SessionKey : IKey
    {
        public string Type { get; }
        public string Key { get; }
        public string Session { get; }

        public SessionKey(Type type, string session, string key)
        {
            if (string.IsNullOrWhiteSpace(session))
                throw new ArgumentNullException(nameof(session));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));

            Type = type.Name.ToLowerInvariant();
            Session = session;
            Key = key;
        }

        public override string ToString()
        {
            return $"{Type}.{Session}.{Key}";
        }
    }
}

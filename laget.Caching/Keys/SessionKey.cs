using laget.Caching.Interfaces;

namespace laget.Caching.Keys
{
    public class SessionKey : IKey
    {
        public string Key { get; }
        public string Session { get; }

        public SessionKey(string key)
        {
            Key = key;
        }

        public SessionKey(string key, string session)
        {
            Key = key;
            Session = session;
        }

        public override string ToString()
        {
            return $"{Session}_{Key}";
        }
    }
}

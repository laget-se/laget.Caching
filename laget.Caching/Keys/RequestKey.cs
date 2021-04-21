using laget.Caching.Interfaces;

namespace laget.Caching.Keys
{
    public class RequestKey : IKey
    {
        public string Key { get; }

        public RequestKey(string key)
        {
            Key = key;
        }

        public override string ToString()
        {
            return Key;
        }
    }
}

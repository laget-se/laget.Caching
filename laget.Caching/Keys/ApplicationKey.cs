using laget.Caching.Interfaces;

namespace laget.Caching.Keys
{
    public class ApplicationKey : IKey
    {
        public string Key { get; }

        public ApplicationKey(string key)
        {
            Key = key;
        }

        public override string ToString()
        {
            return Key;
        }
    }
}

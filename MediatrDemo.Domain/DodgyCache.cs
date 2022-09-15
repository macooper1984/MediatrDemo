using System.Collections.Generic;

namespace MediatrDemo.Domain
{
    public static class DodgyCache
    {
        private static Dictionary<string, object> cache = new Dictionary<string, object>();

        public static bool HasKey(string key)
        {
            return cache.ContainsKey(key);
        }

        public static T GetByKey<T>(string key)
        {
            return (T)cache[key];
        }

        public static void Store<T>(string key, T item)
        {
            cache[key] = item;
        }
    }
}

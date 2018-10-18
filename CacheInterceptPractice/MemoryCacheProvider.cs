using System;
using System.Runtime.Caching;

namespace CacheInterceptPractice
{
    public class MemoryCacheProvider
    {
        public bool Contains(string key)
        {
            return MemoryCache.Default[key] != null;
        }

        public object Get(string key)
        {
            return MemoryCache.Default[key];
        }

        public void Put(string key, object value, int durationMillis)
        {
            MemoryCache.Default.Set(key,value,new DateTimeOffset(DateTime.Now.AddMilliseconds(durationMillis)));
        }
    }
}
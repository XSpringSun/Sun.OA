using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spring.Context;
using Spring.Context.Support;

namespace Sun.OA.Common.Cache
{
    public class CacheHelper
    {
        private static ICacheWriter CacheWriter { get; set; }

        static CacheHelper()
        {
            //spring.net 注入。
            IApplicationContext ctx = ContextRegistry.GetContext();
            CacheWriter = ctx.GetObject("CacheWriter") as ICacheWriter;
        }
        public static void AddCache(string key, object value)
        {
            CacheWriter.AddCache(key, value);
        }
        public static void AddCache(string key, object value, DateTime expDate)
        {
            CacheWriter.AddCache(key, value, expDate);
        }

        public static object GetCache(string key)
        {
            return CacheWriter.GetCache(key);
        }

        public static T GetCache<T>(string key)
        {
            return (T)CacheWriter.GetCache(key);
        }

        public static void SetCache(string key, object value)
        {
            CacheWriter.SetCache(key, value);
        }

        public static void SetCache(string key, object value, DateTime expDate)
        {
            CacheWriter.SetCache(key, value, expDate);
        }
      
    }
}

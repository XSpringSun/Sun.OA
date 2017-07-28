using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Sun.OA.Common.Cache
{
    //用HttpRuntime写缓存（例子）
    public class HttpRuntimeCacheWriter : ICacheWriter
    {
        public void AddCache(string key, object value)
        {
            HttpRuntime.Cache.Insert(key, value);
        }

        public void AddCache(string key, object value, DateTime expDate)
        {
            HttpRuntime.Cache.Insert(key, value, null, expDate, TimeSpan.Zero);
        }

        public object GetCache(string key)
        {
            return HttpRuntime.Cache.Get(key);
        }

        public T GetCahe<T>(string key)
        {
            return (T)HttpRuntime.Cache.Get(key);
        }


        public void SetCache(string key, object value)
        {
            HttpRuntime.Cache.Remove(key);
            AddCache(key, value);
        }

        public void SetCache(string key, object value, DateTime expDate)
        {
            HttpRuntime.Cache.Remove(key);
            AddCache(key, value, expDate);
        }
    }
}

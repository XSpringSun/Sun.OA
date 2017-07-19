using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sun.OA.Common.Cache
{
    public interface ICacheWriter
    {
        void AddCache(string key, object value);

        void AddCache(string key, object value, DateTime expDate);

        object GetCache(string key);

        T GetCahe<T>(string key);

        void SetCache(string key, object value);

        void SetCache(string key, object value, DateTime expDate);
        
    }
}

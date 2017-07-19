using Memcached.ClientLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sun.OA.Common.Cache
{
    public class MemcacheWriter : ICacheWriter
    {
        private MemcachedClient mc;
        public MemcacheWriter()
        {
            //string[] serverlist = new string[] { "127.0.0.1:11211" };
            string[] serverlist = System.Configuration.ConfigurationManager.AppSettings["MemcacheServer"].Split(',');

            SockIOPool pool = SockIOPool.GetInstance();

            //设置连接池的初始容量，最小容量，最大容量，Socket 读取超时时间，Socket连接超时时间

            pool.SetServers(serverlist);

            pool.InitConnections = 3;

            pool.MinConnections = 3;

            pool.MaxConnections = 500;

            pool.SocketConnectTimeout = 1000;

            pool.SocketTimeout = 3000;

            pool.MaintenanceSleep = 30;

            pool.Failover = true;

            pool.Nagle = false;

            pool.Initialize();//容器初始化

            //实例化一个客户端

            mc = new MemcachedClient();

            mc.EnableCompression = false;
        }
        public void AddCache(string key, object value)
        {
            mc.Add(key, value);
        }

        public void AddCache(string key, object value, DateTime expDate)
        {
            mc.Add(key, value, expDate);
        }

        public object GetCache(string key)
        {
            return mc.Get(key);
        }

        public T GetCahe<T>(string key)
        {
            return (T)mc.Get(key);
        }


        public void SetCache(string key, object value)
        {
            mc.Set(key, value);
        }

        public void SetCache(string key, object value, DateTime expDate)
        {
            mc.Set(key, value, expDate);
        }
    }
}

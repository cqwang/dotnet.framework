using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Memcached.ClientLibrary;
using System.Collections;

namespace dotnet.framework.ICache
{
    /// <summary>
    /// Memcache通用类，本例采用长连接
    /// </summary>
    public class MemcachedProxy
    {
        private MemcachedClient client;

        public MemcachedProxy(string[] serverlist, string poolName = "")
        {
            this.client = CreateClient(serverlist, poolName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverlist">IP端口列表</param>
        /// <param name="poolName">Socket连接池名称</param>
        /// <returns></returns>
        private MemcachedClient CreateClient(string[] serverlist, string poolName)
        {
            var pool = SockIOPool.GetInstance(poolName);
            pool.SetServers(serverlist);
            //其他参数根据需要进行配置
            pool.Initialize();

            var client = new MemcachedClient()
            {
                PoolName = poolName,
                EnableCompression = false
            };

            return client;
        }

        public bool Exists(string key)
        {
            return client.KeyExists(key);
        }

        public bool Add(string key, string value, DateTime endDateTime)
        {
            return client.Add(key, value, endDateTime);
        }

        public bool AddOrUpdate(string key, string value, DateTime endDateTime)
        {
            return client.Set(key, value, endDateTime);
        }

        public bool Replace(string key, string value, DateTime endDateTime)
        {
            return client.Replace(key, value, endDateTime);
        }

        public object Get(string key)
        {
            if (client.KeyExists(key))
            {
                return client.Get(key);
            }
            else
            {
                return null;
            }
        }

        public object[] Get(string[] keys)
        {
            object[] list = client.GetMultipleArray(keys);
            var results = new List<object>();
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] != null)
                {
                    results.Add(list[i]);
                }
            }
            return results.ToArray();
        }

        public Hashtable GetMultipleTable(string[] keys)
        {
            return client.GetMultiple(keys);
        }

        public bool Delete(string key)
        {
            return client.Delete(key);
        }

        public bool FlushAll()
        {
            return client.FlushAll();
        }

        public Hashtable Stats()
        {
            return client.Stats();
        }
    }
}

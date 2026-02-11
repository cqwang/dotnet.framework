using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cqwang.BackEnd.CSharp.Memcached.TestCase
{
    class TestMemcachedTest
    {

        static void Main(string[] args)
            {
                TestMemcached.Test();
                Console.ReadKey();
            }
        }

        public static void Test()
        {
            MemcachedProxy proxy = new MemcachedProxy(new string[] { "127.0.0.1:11211" });

            //缓存状态
            var statsTable = proxy.Stats();
            foreach (DictionaryEntry item in statsTable)
            {
                var itemValue = item.Value as Hashtable;
                foreach (DictionaryEntry subItem in itemValue)
                {
                    Console.WriteLine(string.Format("【{0}:{1}】", subItem.Key.ToString(), subItem.Value.ToString()));
                }
            }

            Console.ReadKey();

            //缓存存取、缓存过期
            string key = "小明";
            string value = "好孩子";

            for (int i = 0; i < 10; i++)
            {
                if (i == 7)
                {
                    Thread.Sleep(10000);
                }
                else
                {
                    Thread.Sleep(5000);
                }

                if (proxy.Exists(key))
                {
                    var cachedValue = proxy.Get(key).ToString();
                    Console.Write(string.Format("缓存已经存在：【{0}:{1}】，", key, cachedValue));
                    if (i == 5)
                    {
                        Console.WriteLine("清空缓存");
                        proxy.Delete(key);
                    }
                    else
                    {
                        string newValue = cachedValue.Equals(value) ? "坏孩子" : value;
                        if (proxy.AddOrUpdate(key, newValue, DateTime.Now.AddSeconds(8)))
                        {
                            Console.WriteLine(string.Format("更新为：【{0}:{1}】，8s后过期", key, proxy.Get(key).ToString()));
                        }
                    }
                }
                else
                {
                    if (proxy.Add(key, value, DateTime.Now.AddSeconds(8)))
                    {
                        Console.WriteLine(string.Format("缓存写入成功：【{0}:{1}】，8s后过期", key, proxy.Get(key).ToString()));
                    }
                    else
                    {
                        Console.WriteLine(string.Format("缓存写入失败：【{0}:{1}】", key, proxy.Get(key).ToString()));
                    }
                }
            }

            Console.WriteLine("测试结束");
        }
    }
}

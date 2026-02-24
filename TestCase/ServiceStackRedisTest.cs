
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqwang.BackEnd.CSharp.Redis.TestCase
{
    class ManualHotel
    {
        public int ResourceID { get; set; }

        public int Capacity { get; set; }

        public int StartDay { get; set; }

        public int EndDay { get; set; }

    }

    class ManualHotelGroup
    {
        public int StartDay { get; set; }

        public int EndDay { get; set; }

        public List<ManualHotel> Hotels { get; set; }
    }

    public class ServieStackRedisTest {

        public static void TestGetSet()
        {
            var group = new ManualHotelGroup()
            {
                StartDay = 1,
                EndDay = 2,
                Hotels = new List<ManualHotel>()
                {
                    new ManualHotel()
                    {
                        StartDay=1,
                        EndDay=2,
                        Capacity=2,
                        ResourceID=111
                    }
                }
            };

            var redisDB = ConfigurationManager.AppSettings["RedisDB"] ?? string.Empty;
            var key = string.Concat(redisDB, "_ManualHotelGroupForTest");
            var provider = ServiceStackRedisProviderFactory.CreateProvider();
            provider.SetAsync(key, group);
            System.Threading.Thread.Sleep(2000);
            var cachedGroup = provider.GetAsync<ManualHotelGroup>(key).Result;
        }







        public static void Subscribe(string targetChannel)
        {
            var provider = ServiceStackRedisProviderFactory.CreateProvider();
            var subscription = provider.RedisClient.CreateSubscription();
            subscription.OnMessage = (channel, message) =>
            {
                Console.WriteLine($"从频道：{channel}上接受到消息：{message},时间：{DateTime.Now.ToString("yyyyMMdd HH:mm:ss")}");
                Console.WriteLine($"频道订阅数目：{subscription.SubscriptionCount}");
            };
            subscription.OnSubscribe = (channel) =>
            {
                Console.WriteLine("客户端开始订阅" + channel);
            };
            subscription.OnUnSubscribe = (a) =>
            {
                Console.WriteLine("客户端取消订阅");
            };

            subscription.SubscribeToChannels(targetChannel);
        }

        public static void Publish(string targetChannel, string message)
        {
            var provider = ServiceStackRedisProviderFactory.CreateProvider();
            provider.RedisClient.PublishMessage(targetChannel, message);
        }

        public static void Publish2(string targetChannel, string message)
        {
            var provider = ServiceStackRedisProviderFactory.CreateProvider();
            var server = new RedisPubSubServer(provider.ClientManager, targetChannel)
            {
                OnMessage = (channel, msg) =>
                 {
                     Console.WriteLine($"从频道：{channel}上接受到消息：{msg},时间：{DateTime.Now.ToString("yyyyMMdd HH:mm:ss")}");
                 },
                OnStart = () =>
                {
                    Console.WriteLine("发布服务已启动");
                },
                OnStop = () => { Console.WriteLine("发布服务停止"); },
                OnUnSubscribe = channel => { Console.WriteLine(channel); },
                OnError = e => { Console.WriteLine(e.Message); },
                OnFailover = s => { Console.WriteLine(s); },
            };
            server.Start();
        }


        public void Publish3()
        {
            ISubscriber sub = StackExchangeRedisProviderFactory.CreateProvider().Multiplexer.GetSubscriber();
            sub.Publish("messages", "hello");

            sub.Subscribe("messages", (channel, message) => {
                Console.WriteLine((string)message);
            });
        }
    }




    }
}

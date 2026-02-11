using Apache.NMS;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Newtonsoft.Json;
using Apache.NMS.ActiveMQ;
using System.Threading;

namespace dotnet.framework.IMQ
{
    /// <summary>
    /// 队列名称
    /// </summary>
    class QueueName
    {
        /// <summary>
        /// 灾难
        /// </summary>
        public const string Disaster = "Disaster";

        /// <summary>
        /// 数据同步
        /// </summary>
        public const string SyncData = "SyncData";
    }

    public class ActiveMQManager
    {
        private static bool _isConnected;
        private static IConnection _connection;
        private static readonly ConcurrentDictionary<string, PublishSubscribeModel> ProducerMap = new ConcurrentDictionary<string, PublishSubscribeModel>();

        internal static readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings();

        public static void InitConnection()
        {
            if (_isConnected)
            {
                return;
            }

            var brokerUri = ConfigurationManager.AppSettings["ActiveMq.ConnectionUrl"];
            var factory = new ConnectionFactory(brokerUri);
            _connection = factory.CreateConnection();
            _connection.RequestTimeout = new TimeSpan(0, 0, 3);
            _connection.ConnectionInterruptedListener += () =>
            {
                _isConnected = false;
            };
            _connection.ConnectionResumedListener += () =>
            {
                _isConnected = true;
                HandleDisaster();

                var session = _connection.CreateSession();
                var producer = session.CreateProducer(session.GetQueue("ProducerQueue"));
            };
            _connection.Start();
            _isConnected = true;
        }

        private static void HandleDisaster()
        {
            for (int i = 0; i < 5; i++)
            {
                //RedisStrategy.Dequeue<DisasterMessageModel>(QueueName.Disaster.ToString(), (model) =>
                //{
                //    if (model == null)
                //    {
                //        Thread.Sleep(2000);
                //    }
                //    else
                //    {
                //        try
                //        {
                //            var provider = new ActiveMQProvider<string>(model.QueueName, model.LifeTime);
                //            if (model.IsSendAble())
                //            {
                //                var messageModel = new MessageModel<string>()
                //                {
                //                    Piority = model.Piority,
                //                    DelayMillionSeconds = model.DelayMillionSeconds,
                //                    Body = model.Body
                //                };
                //                provider.Publish(messageModel, false);
                //            }
                //            else
                //            {

                //            }
                //        }
                //        catch (Exception ex)
                //        {
                //            return false;
                //        }
                //    }
                //    return true;
                //});
            }
        }


        public static IMessageProducer CreateProducer(string queueName, NotificationType notificationType)
        {
            PublishSubscribeModel model;
            if (!ProducerMap.TryGetValue(queueName, out model))
            {
                model = new PublishSubscribeModel();
                ProducerMap.TryAdd(queueName, model);
            }
            if (model.Producer == null)
            {
                var session = _connection.CreateSession();
                var destination = (notificationType == NotificationType.Unicast) ? session.GetQueue(queueName) as IDestination : session.GetTopic(queueName) as IDestination;
                model.Producer = session.CreateProducer(destination);
            }
            return model.Producer;
        }

        public static IMessageConsumer CreateConsumer<T>(string queueName, NotificationType notificationType, Func<T, bool> func)
        {
            PublishSubscribeModel model;
            if (!ProducerMap.TryGetValue(queueName, out model))
            {
                model = new PublishSubscribeModel();
                ProducerMap.TryAdd(queueName, model);
            }
            if (model.Consumers == null)
            {
                model.Consumers = new ConcurrentBag<IMessageConsumer>();
            }

            var session = _connection.CreateSession(AcknowledgementMode.Transactional);
            var destination = (notificationType == NotificationType.Unicast) ? session.GetQueue(queueName) as IDestination : session.GetTopic(queueName) as IDestination;
            var consumer = session.CreateConsumer(destination);
            consumer.Listener += (message) =>
            {
                var data = JsonConvert.DeserializeObject<T>(((ITextMessage)message).Text, JsonSettings);
                if (func(data))
                {
                    session.Commit();
                }
                else
                {
                    session.Rollback();
                }
            };
            model.Consumers.Add(consumer);
            return consumer;
        }

        //Task.Run(() =>
        //        {
        //            var session = _connection.CreateSession();
        //            var producer = session.CreateProducer(session.GetQueue("ProducerQueue"));
        //        }).ContinueWith(t =>
        //        {
        //            if (t.Exception != null)
        //            {
        //                //log 报警
        //            }
        //        });
    }

   class PublishSubscribeModel
   {
       public IMessageProducer Producer { get; set; }

       public ConcurrentBag<IMessageConsumer> Consumers { get; set; }
   }
}

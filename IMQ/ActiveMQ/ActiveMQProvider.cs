
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Newtonsoft.Json;

namespace dotnet.framework.IMQ
{
    class ScheduleName
    {
        public const string Delay = "Delay";
    }
    
    public class ActiveMQProvider<T>
    {
        private TimeSpan _lifeTime;
        private string _queueName;

        /// <summary>
        /// 通知类型
        /// </summary>
        public NotificationType _notificationType { get; set; }

        public ActiveMQProvider(string queueName, TimeSpan? lifeTime = null)
        {
            this._queueName = queueName;
            this._lifeTime = lifeTime.HasValue ? lifeTime.Value : new TimeSpan(0);
        }

        /// <summary>
        /// 生产者发布消息
        /// </summary>
        /// <param name="model"></param>
        /// <param name="isNeedJsonSerialize"></param>
        internal void Publish(MessageModel<T> model, bool isNeedJsonSerialize = true)
        {
            var producer = ActiveMQManager.CreateProducer(this._queueName, this._notificationType);
            var messageBody = model.Body == null ? null : model.Body.ToString();
            if (isNeedJsonSerialize)
            {
                messageBody = JsonConvert.SerializeObject(model.Body, ActiveMQManager.JsonSettings);
            }

            var textMessage = producer.CreateTextMessage(messageBody);
            if (model.DelayMillionSeconds.HasValue)
            {
                textMessage.Properties.SetLong(ScheduleName.Delay, model.DelayMillionSeconds.Value);
            }

            producer.Send(textMessage, MsgDeliveryMode.Persistent, model.Piority, _lifeTime);//持久化存储
        }
    }
}

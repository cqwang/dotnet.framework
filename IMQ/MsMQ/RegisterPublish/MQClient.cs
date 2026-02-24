using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Messaging;
using System.Threading;

namespace dotnet.framework.IMQ.MsMQ
{
    public class MQClient
    {
        private MessageQueue clientQueue;

        public MQClient(MQInfo mqInfo)
        {
            clientQueue = MQFactory.GetOrCreateMQ(mqInfo, ClientQueueReceiveCompleted);
            clientQueue.Label = "client" + DateTime.Now.Ticks;
            clientQueue.BeginReceive();
            clientQueue.Close();
        }

        /// <summary>
        /// 注册
        /// </summary>
        public void Register()
        {
            try
            {
                Message message = new Message("register");
                message.Label = clientQueue.Label;
                message.ResponseQueue = clientQueue;
                clientQueue.Send(message);
            }
            catch (MessageQueueException MQException)
            {
                Console.WriteLine(MQException.Message);
            }
        }

        /// <summary>
        /// 反注册
        /// </summary>
        public void Unregister()
        {
            try
            {
                Message message = new Message("unregister");
                message.Label = clientQueue.Label;
                clientQueue.Send(message);
            }
            catch (MessageQueueException MQException)
            {
                Console.WriteLine(MQException.Message);
            }
        }

        /// <summary>
        /// 接收处理消息
        /// </summary>
        /// <param name="source"></param>
        /// <param name="asyncResult"></param>
        private void ClientQueueReceiveCompleted(Object source, ReceiveCompletedEventArgs asyncResult)
        {
            try
            {
                Message message = clientQueue.EndReceive(asyncResult.AsyncResult);

                if (message.Body is string)
                {
                    Console.WriteLine(message.Body.ToString());
                }

            }
            catch (MessageQueueException e)
            {
                Console.WriteLine(String.Format(System.Globalization.CultureInfo.CurrentCulture,
                    "Failed to receive Message: {0} ", e.ToString()));
            }

            //Begin the next Asynchronous Receive Operation
            clientQueue.BeginReceive();
        }
    }
}

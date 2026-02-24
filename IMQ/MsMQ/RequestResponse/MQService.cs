using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Messaging;

namespace dotnet.framework.IMQ.MsMQ
{
    public class MQService
    {
        private MessageQueue serviceQueue;

        public MQService(MQInfo mqInfo)
        {
            serviceQueue = MQFactory.GetOrCreateMQ(mqInfo, MessageListenerEventHandler);
            serviceQueue.BeginReceive();
            serviceQueue.Close();
        }

        /// <summary>
        /// 接收处理消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MessageListenerEventHandler(object sender, ReceiveCompletedEventArgs e)
        {
            try
            {
                MessageQueue mq = sender as MessageQueue;
                Message msg = mq.EndReceive(e.AsyncResult);

                string str = msg.Body.ToString();
                if (str == "Hi")
                {
                    msg.ResponseQueue.Send("Hi,too");
                }
                else if (str == "Is it beautiful?")
                {
                    msg.ResponseQueue.Send(true);
                }

                // Restart the asynchronous receive operation.
                mq.BeginReceive();
            }
            catch (MessageQueueException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

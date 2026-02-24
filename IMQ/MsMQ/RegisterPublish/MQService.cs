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

        /// <summary>
        /// 注册列表
        /// </summary>
        private Dictionary<string, MessageQueue> clientQueues = new Dictionary<string, MessageQueue>();


        public MQService(MQInfo mqInfo)
        {
            serviceQueue = MQFactory.GetOrCreateMQ(mqInfo, MessageListenerEventHandler);
            serviceQueue.BeginReceive();
            serviceQueue.Close();
        }

        /// <summary>
        /// 处理注册或反注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MessageListenerEventHandler(object sender, ReceiveCompletedEventArgs e)
        {
            try
            {
                MessageQueue mq = sender as MessageQueue;
                Message msg = mq.EndReceive(e.AsyncResult);

                //register or unregister or notify
                string str = msg.Body.ToString();
                if (str == "register")
                {
                    clientQueues.Add(msg.Label, msg.ResponseQueue);
                }
                else if (str == "unregister")
                {
                    clientQueues[msg.Label].Purge();
                    clientQueues.Remove(msg.Label);
                }

                // Restart the asynchronous receive operation.
                mq.BeginReceive();
            }
            catch (MessageQueueException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 广播消息
        /// </summary>
        /// <param name="str"></param>
        public void Notify(Message message)
        {
            if (clientQueues.Count > 0)
            {
                string str = message.Body.ToString();
                foreach (MessageQueue mq in clientQueues.Values)
                {
                    mq.Send(str);
                }
            }
        }
    }
}

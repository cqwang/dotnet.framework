using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Messaging;

namespace dotnet.framework.IMQ.MsMQ
{
    public class MQFactory
    {
        /// <summary>
        /// 创建消息队列的引用，若不存在则创建消息队列
        /// </summary>
        /// <param name="mqInfo"></param>
        /// <returns></returns>
        public static MessageQueue GetOrCreateMQ(MQInfo mqInfo, ReceiveCompletedEventHandler receiveHandler = null)
        {
            MessageQueue messageQueue = null;
            try
            {
                if (MessageQueue.Exists(mqInfo.PathName))
                {
                    messageQueue = new MessageQueue(mqInfo.PathName); //若已经存在，则创建指向它的引用
                }
                else
                {
                    messageQueue = MessageQueue.Create(mqInfo.PathName); //根据指定路径创建新的消息队列
                    messageQueue.Close();
                }
            }
            catch (MessageQueueException e)
            {
                Console.WriteLine(e.Message);
            }

            messageQueue.Formatter = mqInfo.Formatter;
            if (receiveHandler != null)
                messageQueue.ReceiveCompleted += receiveHandler;
            return messageQueue;
        }
    }
}
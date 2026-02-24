using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Messaging;

namespace dotnet.framework.IMQ.MsMQ
{
    public class MQClient
    {
        private MessageQueue clientQueue;

        public MQClient(MQInfo mqInfo)
        {
            clientQueue = MQFactory.GetOrCreateMQ(mqInfo);
            clientQueue.BeginReceive();
            clientQueue.Close();
        }

        public void SendRequest()
        {
            try
            {
                Message message = new Message("Hi");
                message.ResponseQueue = clientQueue;
                clientQueue.Purge();
                clientQueue.Send(message);

                Message msg = clientQueue.Receive(new TimeSpan(0, 0, 4));
                Console.WriteLine(msg.Body.ToString());
            }
            catch (MessageQueueException MQException)
            {
                Console.WriteLine(MQException.Message);
            }
        }

        /// <summary>
        /// 向队列发送消息
        /// </summary>
        /// <param name="messageQueue"></param>
        /// <param name="message"></param>
        public void SendMessage(MessageQueue messageQueue, Message message)
        {
            if (messageQueue.Transactional)
                SendMessageTransactional(messageQueue, message);
            else
                messageQueue.Send(message);
        }
        /// <summary>
        /// 向事务性队列发送消息
        /// </summary>
        /// <param name="messageQueue"></param>
        /// <param name="message"></param>
        private void SendMessageTransactional(MessageQueue messageQueue, Message message)
        {
            MessageQueueTransaction tran = new MessageQueueTransaction();
            try
            {
                tran.Begin();
                messageQueue.Send(message, tran);
                tran.Commit();
            }
            catch (Exception e)
            {
                tran.Abort();
                //Console.WriteLine(string.Concat("Abort: ",message.Body.ToString()));
            }
        }

        /// <summary>
        /// 接收并处理单个消息
        /// </summary>
        /// <param name="messageQueue"></param>
        /// <param name="receiveMode"></param>
        /// <param name="isDeleted"></param>
        public void ReceiveAndHandleMessage(MessageQueue messageQueue, ReceiveMode receiveMode, bool isDeleted)
        {
            if (receiveMode == ReceiveMode.Asynchronouse)
            {
                if (isDeleted)
                    messageQueue.BeginReceive();
                else
                    messageQueue.BeginPeek();
            }
            else
            {
                Message message = isDeleted ?
                    messageQueue.Receive() : //读取队列中的第一条消息，在这个过程中将它从队列中删除。so确保你的进程是唯一收到消息的进程。
                    messageQueue.Peek(); //领取队列中的第一条消息，而不从队列中移除该消息
                HandleMessage(message);
            }
        }

        public void ReceiveAndHandleMessages(MessageQueue messageQueue, bool isLarge, bool isDeleted)
        {
            if (isLarge)
            {
                //逐个读取消息保存在当前内存中，适用于非常庞大的队列
                MessageEnumerator enumerator = messageQueue.GetMessageEnumerator2();
                Message msg;
                while (enumerator.MoveNext())
                {
                    msg = isDeleted ?
                        enumerator.RemoveCurrent() : //检查队列中的每一条消息，再删除它
                        enumerator.Current;
                    HandleMessage(msg);
                }
            }
            else
            {
                //从队列中取出所有消息的副本，把它们保存在当前内存中，然后一次性处理它们
                Message[] messages = messageQueue.GetAllMessages();
                foreach (Message message in messages)
                {
                    HandleMessage(message);
                }
            }
        }

        /// <summary>
        /// 处理消息
        /// </summary>
        /// <param name="message"></param>
        private void HandleMessage(Message message)
        {
            //Console.WriteLine(message.Body.ToString());
            message.ResponseQueue.Send("收到" + message.Body.ToString());
            //using (System.IO.StreamWriter writer = new System.IO.StreamWriter(@".\a.txt"))
            //{
            //    writer.WriteLine(message.Body.ToString());
            //}
        }
    }
}

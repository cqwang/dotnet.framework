using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Configuration;

namespace dotnet.framework.Log.File
{
    public class SingleLogPool
    {
        private static readonly ConcurrentQueue<LogFileMessage> InfoQueue = new ConcurrentQueue<LogFileMessage>();

        //private static readonly Timer timer = new Timer(Write);//也可以使用定时器

        private const int MaxCountPerTime = 50;
        private const int SleepSeconds = 10000;

private static bool IsLocalLogOpen =!string.Equals("false", ConfigurationManager.AppSettings["IsLocalLogOpen"],
            StringComparison.CurrentCultureIgnoreCase);

        public static void Start()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {

if (!IsLocalLogOpen)
                    {
                        break;
                    }
                    Thread.Sleep(SleepSeconds);
                    if (InfoQueue.Count > 0)
                    {
                        var times = InfoQueue.Count.Partition(MaxCountPerTime);
                        for (int i = 0; i < times; i++)
                        {
                            int num = MaxCountPerTime;
                            LogFileMessage logMessage;
                            while (num > 0 && InfoQueue.TryDequeue(out logMessage))
                            {
                                if (logMessage.MessageType == LogType.Info)
                                {
                                    Logger.Write(logMessage.ToString());
                                }
                                else if (logMessage.MessageType == LogType.Error)
                                {
                                    Logger.Write(logMessage.ToString(), logMessage.Ex);
                                }
                                num--;
                            }
                        }
                    }
                }

            }).ContinueWith(t =>
            {
                try
                {
                    if (t.Exception != null)
                    {
IsLocalLogOpen = false;
                        Logger.Write("异步批量记录日志异常：", t.Exception);
                    }
                }
                catch { }
            });
        }

        public static void Write(LogFileMessage message)
        {
if (!IsLocalLogOpen)
            {
                return;
            }
            InfoQueue.Enqueue(message);
        }
    }
}

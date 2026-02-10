using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dotnet.framework.Log.File
{
    internal class BatchLogPool
    {
        internal static readonly ConcurrentQueue<LogFileMessage> MessageQueue = new ConcurrentQueue<LogFileMessage>();
        private const int MaxCountPerTime = 50;
        private const int SleepSeconds = 10000;
        private const int FailMaxTryTimes = 3;

        

        static LogPool()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Log4net.config");
            FileLogger.SetConfig(path);
            Start();
        }

        private static void Start()
        {
            Task.Factory.StartNew(() =>
            {
                var failTimes = 0;
                while (true)
                {
                    try
                    {
                        if (!FileLogConfig.IsLocalLogOpen)
                        {
                            break;
                        }

                        Thread.Sleep(SleepSeconds);
                        if (MessageQueue.Count <= 0) continue;

                        BatchLog();
                    }
                    catch (Exception e)
                    {
                        failTimes++;
                        if (failTimes >= FailMaxTryTimes)
                        {
                            FileLogConfig.IsLocalLogOpen = false;
                            FileLogger.Error("记录日志异常次数超限，自动关闭日志");
                        }
                        FileLogger.Error("异步批量记录日志异常：" + e);
                    }
                }
            }).ContinueWith(t =>
            {
                if (t.Exception != null)
                {
                    FileLogConfig.IsLocalLogOpen = false;
                }
            });
        }

        private static void BatchLog()
        {
            var times = Partition(MessageQueue.Count, MaxCountPerTime);
            for (var i = 0; i < times; i++)
            {
                var num = MaxCountPerTime;
                var map = new Dictionary<LogType, StringBuilder>();
                while (num > 0 && MessageQueue.TryDequeue(out var logMessage))
                {
                    if (!map.TryGetValue(logMessage.MessageType, out var sb))
                    {
                        sb = new StringBuilder();
                    }
                    sb.AppendLine($"{logMessage}");
                    num--;
                }

                if (map.TryGetValue(LogType.Info, out var content))
                {
                    FileLogger.Info(content.ToString());
                }
                if (map.TryGetValue(LogType.Error, out content))
                {
                    FileLogger.Error(content.ToString());
                }
                map.Clear();
            }
        }

        /// <summary>
        /// 划分
        /// </summary>
        /// <param name="length"></param>
        /// <param name="subLength"></param>
        /// <returns></returns>
        private static int Partition(int length, int subLength)
        {
            var subCount = length / subLength;
            return (length % subLength == 0) ? subCount : subCount + 1;
        }
    }
}

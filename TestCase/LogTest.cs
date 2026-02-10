using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Cqwang.BackEnd.CSharp.Log;

namespace dotnet.common.TestCase
{
    class LogTest
    {
        static void Main(string[] args)
        {
            DBAppender.LogPool.Start();
            for (int i = 0; i < 1; i++)
            {
                DBAppender.Logger.Info("666", "345", "567");
            }

            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Config/Log4net.config");
            FileAppender.Logger.SetConfig(path);
            FileAppender.LogPool.Start();
            for (int i = 0; i < 12; i++)
            {
                FileAppender.LogPool.Write(new FileAppender.LogFileMessage() { MessageContent = "MessageContent", MessageGroup = "MessageGroup", MessageType = FileAppender.LogType.Info, Timestamp = DateTime.Now });
            }

            while(true)
            {
                System.Threading.Thread.Sleep(5000);
                Console.WriteLine(DateTime.Now);
            }
            Console.ReadKey();
        }
    }
}

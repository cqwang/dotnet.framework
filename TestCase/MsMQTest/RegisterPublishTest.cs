using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Messaging;
using Cqwang.BackEnd.CSharp.MSMQ.RegisterPublish;

namespace Cqwang.BackEnd.CSharp.MSMQ.TestCase
{
    class Test
    {
        static void DoTest()
        {
            MQInfo mqInfo = new MQInfo()
            {
                PathName = @"MachineName\Private$\myQueue",
                Formatter = new XmlMessageFormatter(new Type[] { typeof(string) })
            };

            MQService service = new MQService(mqInfo);
            MQClient client1 = new MQClient(mqInfo);
            client1.Register();
            MQClient client2 = new MQClient(mqInfo);
            client2.Register();

            Message message = new Message("广播一下下啊！");
        }
    }
}

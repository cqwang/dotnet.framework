using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet.framework.TestCase
{
    class TestRegisterPublish
    {
        public static void Test()
        {
            ActiveMQManager.CreateConsumer<SyncData>(QueueName.SyncData, NotificationType.Unicast, (syncData) =>
            {
                Console.WriteLine(string.Join("|", syncData.DB, syncData.Table, syncData.ID.ToString(), syncData.Operate.ToString()));
                return true;
            });
        }
    }

    class TestRequestResponse
    {
        public static void Test()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Task.Factory.StartNew(() =>
            {
                Application.Run(new ConsumerForm());
            });
            Application.Run(new ProducerForm());
        }
    }
}

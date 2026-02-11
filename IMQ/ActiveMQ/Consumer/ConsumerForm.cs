using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Threading;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;

namespace Cqwang.BackEnd.CSharp.ActiveMQ
{
    public partial class ConsumerForm : Form
    {
        private int _count;
        private IConnectionFactory _factory;

        public ConsumerForm()
        {
            InitializeComponent();
            InitActiveMQ();
        }

        public void InitActiveMQ()
        {
            try
            {
                var brokerUri = ConfigurationManager.AppSettings["ActiveMq.ConnectionUrl"];
                _factory = new ConnectionFactory(brokerUri);
            }
            catch(Exception ex)
            {
                this.richTextBox.Text = "ActiveMQ初始化失败: " + ex.Message;
            }
        }

        private void buttonReceive_Click(object sender, EventArgs e)
        {
            using (IConnection connection = _factory.CreateConnection())
            {
                connection.ClientId = "ClientId001";
                connection.Start();
                using (ISession session = connection.CreateSession())
                {
                    IMessageConsumer consumer = session.CreateConsumer(new ActiveMQQueue("ProducerQueue"), "MessageID='123'");
                    //consumer.Listener += new MessageListener(consumer_Listener);
                    while (true)
                    {
                        ProducerForm.ProducerAutoResetEvent.WaitOne();
                        Interlocked.Increment(ref _count);
                        var message = consumer.Receive();
                        ShowMessage(((ITextMessage)message).Text);
                        ProducerForm.ConsumerAutoResetEvent.Set();
                    }
                }
            }
        }

        private new delegate void Show(string message);

        public void ShowMessage(string message)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Show(ShowMessage), message);
            }
            else
            {
                this.richTextBox.Text = string.Format(@"已成功接收消息数为{0}，最新的一跳消息:{1}{2}", _count.ToString(), message, Environment.NewLine);
                this.Update();
            }
        }

        private static void consumer_Listener(IMessage message)
        {
            try
            {
                ITextMessage msg = message as ITextMessage;
                if (null != msg)
                    Console.WriteLine("Receive: " + msg.Text);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }
    }
}

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
    public partial class ProducerForm : Form
    {
        private int _count;
        public static AutoResetEvent ProducerAutoResetEvent = new AutoResetEvent(false);
        public static AutoResetEvent ConsumerAutoResetEvent = new AutoResetEvent(false);

        private IConnectionFactory _factory;

        public ProducerForm()
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
                this.statusLabel.Text = "ActiveMQ初始化失败: " + ex.Message;
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            using (IConnection connection = _factory.CreateConnection())
            {
                using (ISession session = connection.CreateSession())
                {
                    IMessageProducer prod = session.CreateProducer(new ActiveMQQueue("ProducerQueue"));
                    while (true)
                    {
                        ITextMessage message = prod.CreateTextMessage();
                        message.Text = this.richTextBox.Text + "(" + DateTime.Now.ToString("HH:mm:ss") + ")";
                        message.Properties.SetString("MessageID", "123");
                        prod.Send(message, MsgDeliveryMode.NonPersistent, MsgPriority.Normal, TimeSpan.MinValue);
                        this.statusLabel.Text = DateTime.Now.ToString("HH:mm:ss") + ": 发送成功!";

                        Interlocked.Increment(ref _count);
                        if (_count % 10000 == 0)
                        {
                            break;
                        }
                        ProducerAutoResetEvent.Set();
                        ConsumerAutoResetEvent.WaitOne();
                    }
                }
            }
        }
    }
}

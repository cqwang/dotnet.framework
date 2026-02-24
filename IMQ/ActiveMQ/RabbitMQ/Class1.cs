using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet.framework.IMQ
{
    public class Class1
    {
        public static void Init()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            string exchangeName = "test.exchange";
            string queueName = "test1.queue";
            string otherQueueName = "test2.queue";
            using (IConnection conn = factory.CreateConnection())
            using (IModel channel = conn.CreateModel())
            {
                //2 定义一个exchange
                channel.ExchangeDeclare(exchangeName, "direct", durable: true, autoDelete: false, arguments: null);

                //4 定义两个queue
                channel.QueueDeclare(queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
                channel.QueueDeclare(otherQueueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

                //3 定义exchange到queue的binding
                channel.QueueBind(queueName, exchangeName, routingKey: queueName);
                channel.QueueBind(otherQueueName, exchangeName, routingKey: otherQueueName);
            }
        }

        public static void Send()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            string exchangeName = "test.exchange";
            string queueName = "test1.queue";
            string otherQueueName = "test2.queue";
            using (IConnection conn = factory.CreateConnection())
            using (IModel channel = conn.CreateModel())
            {
                var props = channel.CreateBasicProperties();
                props.Persistent = true;

                var msgBody = Encoding.UTF8.GetBytes("Hello, World!");

                //1. 发送消息到exchange ，但加上routingkey
                channel.BasicPublish(exchangeName, routingKey: queueName, basicProperties: props, body: msgBody);
                channel.BasicPublish(exchangeName, routingKey: otherQueueName, basicProperties: props, body: msgBody);
            }
        }

        public static void Receive()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            string queueName = "test1.queue";
            string otherQueueName = "test2.queue";
            using (IConnection conn = factory.CreateConnection())
            using (IModel channel = conn.CreateModel())
            {
                //5. 从test1.queue 队列获取消息
                //BasicGetResult msgResponse = channel.BasicGet(queueName, noAck: true);
                //string msgBody = Encoding.UTF8.GetString(msgResponse.Body);

                //5. 从test2.queue 队列获取消息
                //msgResponse = channel.BasicGet(otherQueueName, noAck: true);
                //msgBody = Encoding.UTF8.GetString(msgResponse.Body);

            }
        }

        public static void Direct()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                // Direct类型的exchange, 名称 pdf_events
                channel.ExchangeDeclare(exchange: "pdf_events",
                                        type: ExchangeType.Direct,
                                        durable: true,
                                        autoDelete: false,
                                        arguments: null);

                // 创建create_pdf_queue队列
                channel.QueueDeclare(queue: "create_pdf_queue",
                                        durable: true,
                                        exclusive: false,
                                        autoDelete: false,
                                        arguments: null);

                //创建 pdf_log_queue队列
                channel.QueueDeclare(queue: "pdf_log_queue",
                                        durable: true,
                                        exclusive: false,
                                        autoDelete: false,
                                        arguments: null);

                //绑定 pdf_events --> create_pdf_queue 使用routingkey:pdf_create
                channel.QueueBind(queue: "create_pdf_queue",
                                    exchange: "pdf_events",
                                    routingKey: "pdf_create",
                                    arguments: null);

                //绑定 pdf_events --> pdf_log_queue 使用routingkey:pdf_log
                channel.QueueBind(queue: "pdf_log_queue",
                                    exchange: "pdf_events",
                                    routingKey: "pdf_log",
                                    arguments: null);


                var message = "Demo some pdf creating...";
                var body = Encoding.UTF8.GetBytes(message);
                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;

                //发送消息到exchange :pdf_events ,使用routingkey: pdf_create
                //通过binding routinekey的比较，次消息会路由到队列 create_pdf_queue
                channel.BasicPublish(exchange: "pdf_events",
                            routingKey: "pdf_create",
                            basicProperties: properties,
                            body: body);

                message = "pdf loging ...";
                body = Encoding.UTF8.GetBytes(message);
                properties = channel.CreateBasicProperties();
                properties.Persistent = true;

                //发送消息到exchange :pdf_events ,使用routingkey: pdf_log
                //通过binding routinekey的比较，次消息会路由到队列 pdf_log_queue
                channel.BasicPublish(exchange: "pdf_events",
                        routingKey: "pdf_log",
                        basicProperties: properties,
                        body: body);


            }
        }

        public static void Topic()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                // Topic类型的exchange, 名称 agreements
                channel.ExchangeDeclare(exchange: "agreements",
                                        type: ExchangeType.Topic,
                                        durable: true,
                                        autoDelete: false,
                                        arguments: null);

                // 创建berlin_agreements队列
                channel.QueueDeclare(queue: "berlin_agreements",
                                        durable: true,
                                        exclusive: false,
                                        autoDelete: false,
                                        arguments: null);

                //创建 all_agreements 队列
                channel.QueueDeclare(queue: "all_agreements",
                                        durable: true,
                                        exclusive: false,
                                        autoDelete: false,
                                        arguments: null);

                //创建 headstore_agreements 队列
                channel.QueueDeclare(queue: "headstore_agreements",
                                        durable: true,
                                        exclusive: false,
                                        autoDelete: false,
                                        arguments: null);

                //绑定 agreements --> berlin_agreements 使用routingkey:agreements.eu.berlin.#
                channel.QueueBind(queue: "berlin_agreements",
                                    exchange: "agreements",
                                    routingKey: "agreements.eu.berlin.#",
                                    arguments: null);

                //绑定 agreements --> all_agreements 使用routingkey:agreements.#
                channel.QueueBind(queue: "all_agreements",
                                    exchange: "agreements",
                                    routingKey: "agreements.#",
                                    arguments: null);

                //绑定 agreements --> headstore_agreements 使用routingkey:agreements.eu.*.headstore
                channel.QueueBind(queue: "headstore_agreements",
                                    exchange: "agreements",
                                    routingKey: "agreements.eu.*.headstore",
                                    arguments: null);


                var message = "hello world";
                var body = Encoding.UTF8.GetBytes(message);
                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;

                //发送消息到exchange :agreements ,使用routingkey: agreements.eu.berlin
                //agreements.eu.berlin 匹配  agreements.eu.berlin.# 和agreements.#
                //agreements.eu.berlin 不匹配  agreements.eu.*.headstore
                //最终次消息会路由到队里：berlin_agreements（agreements.eu.berlin.#） 和 all_agreements（agreements.#）
                channel.BasicPublish(exchange: "agreements",
                                        routingKey: "agreements.eu.berlin",
                                        basicProperties: properties,
                                        body: body);


            }
        }

        public static void Header()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                // Headers类型的exchange, 名称 agreements
                channel.ExchangeDeclare(exchange: "agreements",
                                        type: ExchangeType.Headers,
                                        durable: true,
                                        autoDelete: false,
                                        arguments: null);

                // 创建queue.A队列
                channel.QueueDeclare(queue: "queue.A", durable: true, exclusive: false, autoDelete: false, arguments: null);

                //创建 queue.B 队列
                channel.QueueDeclare(queue: "queue.B", durable: true, exclusive: false, autoDelete: false, arguments: null);

                //创建 queue.C 队列
                channel.QueueDeclare(queue: "queue.C", durable: true, exclusive: false, autoDelete: false, arguments: null);

                //绑定 agreements --> queue.A 使用arguments (format=pdf, type=report, x-match=all)
                Dictionary<string, object> aHeader = new Dictionary<string, object>();
                aHeader.Add("format", "pdf");
                aHeader.Add("type", "report");
                aHeader.Add("x-match", "all");
                channel.QueueBind(queue: "queue.A",
                                    exchange: "agreements",
                                    routingKey: string.Empty,
                                    arguments: aHeader);

                //绑定 agreements --> queue.B 使用arguments (format=pdf, type=log, x-match=any)
                Dictionary<string, object> bHeader = new Dictionary<string, object>();
                bHeader.Add("format", "pdf");
                bHeader.Add("type", "log");
                bHeader.Add("x-match", "any");
                channel.QueueBind(queue: "queue.B",
                                    exchange: "agreements",
                                    routingKey: string.Empty,
                                    arguments: bHeader);

                //绑定 agreements --> queue.C 使用arguments (format=zip, type=report, x-match=all)
                Dictionary<string, object> cHeader = new Dictionary<string, object>();
                cHeader.Add("format", "zip");
                cHeader.Add("type", "report");
                cHeader.Add("x-match", "all");
                channel.QueueBind(queue: "queue.C",
                                    exchange: "agreements",
                                    routingKey: string.Empty,
                                    arguments: cHeader);


                string message1 = "hello world";
                var body = Encoding.UTF8.GetBytes(message1);
                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;
                Dictionary<string, object> mHeader1 = new Dictionary<string, object>();
                mHeader1.Add("format", "pdf");
                mHeader1.Add("type", "report");
                properties.Headers = mHeader1;
                //此消息路由到 queue.A 和 queue.B
                //queue.A 的binding (format=pdf, type=report, x-match=all)
                //queue.B 的binding (format = pdf, type = log, x - match = any)
                channel.BasicPublish(exchange: "agreements",
                                        routingKey: string.Empty,
                                        basicProperties: properties,
                                        body: body);


                string message2 = "hello world";
                body = Encoding.UTF8.GetBytes(message2);
                properties = channel.CreateBasicProperties();
                properties.Persistent = true;
                Dictionary<string, object> mHeader2 = new Dictionary<string, object>();
                mHeader2.Add("type", "log");
                properties.Headers = mHeader2;
                //x-match 配置queue.B 
                //queue.B 的binding (format = pdf, type = log, x-match = any)
                channel.BasicPublish(exchange: "agreements",
                                routingKey: string.Empty,
                                basicProperties: properties,
                                body: body);

                string message3 = "hello world";
                body = Encoding.UTF8.GetBytes(message3);
                properties = channel.CreateBasicProperties();
                properties.Persistent = true;
                Dictionary<string, object> mHeader3 = new Dictionary<string, object>();
                mHeader3.Add("format", "zip");
                properties.Headers = mHeader3;
                //配置失败，不会被路由
                channel.BasicPublish(exchange: "agreements",
                                routingKey: string.Empty,
                                basicProperties: properties,
                                body: body);


            }
        }
    }
}

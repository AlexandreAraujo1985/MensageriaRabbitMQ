using System;
using System.Text;
using System.Threading;
using RabbitMQ.Client;
using static System.Console;

namespace Producer.Application
{
    public class ProducerQueue : IProducerQueue
    {
        public void BasicPublish()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                //Send message 5 secunds
                while (true)
                {
                    var message = $"{Guid.NewGuid()} Hello World!!!";
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                                         routingKey: "hello",
                                         basicProperties: null,
                                         body: body);
                    WriteLine($" [x] Sent {message}");
                    Thread.Sleep(5000);
                }
            }
        }
    }
}

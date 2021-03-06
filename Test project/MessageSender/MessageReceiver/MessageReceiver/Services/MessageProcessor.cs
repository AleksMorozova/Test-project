using Consumer.Services;
using MessageReceiver.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessageReceiver.Services
{
    class MessageProcessor
    {
        private UserService _userService;
        public MessageProcessor(UserService userService)
        {
            _userService = userService;
        }

        public void StartReceivingMessages()
        {
            OperationType[] operations = { OperationType.Add, OperationType.All };
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "userMessage", type: "topic");
                var queueName = channel.QueueDeclare().QueueName;

                foreach (var bindingKey in operations)
                {
                    channel.QueueBind(queue: queueName,
                                      exchange: "userMessage",
                                      routingKey: bindingKey.ToString());
                }


                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    Enum.TryParse(ea.RoutingKey, out OperationType routingKey);
                    switch (routingKey)
                    {
                        case OperationType.Add:
                            var body = ea.Body.ToArray();
                            var userName = Encoding.UTF8.GetString(body);
                            _userService.CreateUser(userName);
                            break;
                        default:
                            Console.WriteLine("Default case");
                            break;
                    }
                };
                channel.BasicConsume(queue: queueName,
                                     autoAck: true,
                                     consumer: consumer);
                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            } 
        }
    }
}

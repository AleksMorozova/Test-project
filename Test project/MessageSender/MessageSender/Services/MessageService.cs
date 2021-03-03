using RabbitMQ.Client;
using System.Text;

namespace MessageSender.Services
{
    public class MessageService
    {
        public void SendMessage(string routingKey, string message = "")
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "userMessage", type: "topic");

                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: "userMessage",
                                     routingKey: routingKey,
                                     basicProperties: null,
                                     body: body);
            }
        }
    }
}

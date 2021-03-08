using RabbitMQ.Client;
using System.Text;

namespace MessageSender.Services
{
    public class MessageService
    {
        public void SendMessage(string message = "")
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "addUser",
                                        type: ExchangeType.Direct);

                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: "addUser",
                                     routingKey: "",
                                     basicProperties: null,
                                     body: body);
            }
        }
    }
}

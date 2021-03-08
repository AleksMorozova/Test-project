using Consumer.Services;
using DataAccess;
using DataAccess.Repositories;
using MessageReceiver.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp11
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ApplicationContext>()
                .AddSingleton<IUserRepository, UserRepository>()
                .AddSingleton<UserService, UserService>()
                .AddSingleton<MessageProcessor, MessageProcessor>()
                .BuildServiceProvider();

            var processor = serviceProvider.GetService<MessageProcessor>();
            processor.StartReceivingMessages();
        }
    }
}

﻿using MessageReceiver.Services;
using DataAccess;
using DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace MessageReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new LoggerConfiguration()
               .WriteTo.File("log.txt")
               .CreateLogger();

            var serviceProvider = new ServiceCollection()
                .AddSingleton<ApplicationContext>()
                .AddSingleton<IUserRepository, UserRepository>()
                .AddSingleton<UserService, UserService>()
                .AddSingleton<MessageProcessor, MessageProcessor>()
                .AddLogging(builder =>
                {
                    builder.SetMinimumLevel(LogLevel.Information);
                    builder.AddSerilog(logger: logger, dispose: true);
                })
                .BuildServiceProvider();

            var processor = serviceProvider.GetService<MessageProcessor>();
            processor.StartReceivingMessages();
        }
    }
}

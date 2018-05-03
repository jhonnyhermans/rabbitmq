using JH.RabbitMq.Application.Services.Interfaces;
using JH.RabbitMq.Application.ViewModels;
using JH.RabbitMq.Publisher.Config;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using System;
using System.Text;
using System.Threading.Tasks;

namespace JH.RabbitMq.Publisher
{
    class Program
    {

        private static ICollectDataAppService _collectDataAppService;

        static void Mains(string[] args)
        {
         
        }



        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(5000);

            // Configurations
            var rabbitMqConfigurations = RabbitMQConfigurations.Factory.Create();
            var apiTokenConfiguration = ApiTokenConfiguration.Factory.Create();

            // DI
            var serviceProvider = new ServiceCollection()
                 .AddLogging()
                 .AddDIConfiguration()
                 .BuildServiceProvider();
            _collectDataAppService = serviceProvider.GetService<ICollectDataAppService>();


            // Rabbit
            Task task;
            task = Task.Factory.StartNew(() => {

                for (int i = 0; i < 1; i++)
                {

                    // collect data
                    var taskGet = Task.Run(async () => await _collectDataAppService.CollectData(new CollectDataViewModel(
                        apiTokenConfiguration.Locale,
                        apiTokenConfiguration.Token,
                        DateTime.Now.AddDays(i * -1).Date.ToString("yyyy-MM-dd"))));
                    taskGet.Wait();
                    var result = taskGet.Result;

                    //var result = _collectDataAppService.CollectData(new CollectDataViewModel(
                    //    apiTokenConfiguration.Locale, 
                    //    apiTokenConfiguration.Token, 
                    //    DateTime.Now.AddDays(i * -1).Date.ToString("yyyy-MM-dd")));


                    var factory = new ConnectionFactory()
                    {
                        HostName = rabbitMqConfigurations.HostName,
                        Port = rabbitMqConfigurations.Port,
                        UserName = rabbitMqConfigurations.UserName,
                        Password = rabbitMqConfigurations.PassWord
                    };


                    using (var connection = factory.CreateConnection())
                    using (var chanel = connection.CreateModel())
                    {

                        chanel.QueueDeclare(queue: "CollectData",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);


                        var body = Encoding.UTF8.GetBytes(result.Content);

                        chanel.BasicPublish(exchange: "",
                                        routingKey: "CollectData",
                                        basicProperties: null,
                                        body: body);

                    }


                    Console.WriteLine("message sent.");
                    System.Threading.Thread.Sleep(5000);
                }

            });

            //task.Wait();
            Console.WriteLine("Press a key to exit.");
            Console.ReadKey();
        }

    }
}

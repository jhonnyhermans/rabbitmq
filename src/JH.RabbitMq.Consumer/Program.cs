using JH.RabbitMq.Application.DTOs;
using JH.RabbitMq.Application.Services.Interfaces;
using JH.RabbitMq.Application.ViewModels;
using JH.RabbitMq.Consumer.Config;
using JH.RabbitMq.Domain;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace JH.RabbitMq.Consumer
{
    class Program
    {

        private static IPersistDataAppService _persistDataAppService;
        static void Main(string[] args)
        {

            // Configurations
            var rabbitMqConfigurations = RabbitMQConfigurations.Factory.Create();

            // DI
            var serviceProvider = new ServiceCollection()
                 .AddLogging()
                 .AddDIConfiguration()
                 .BuildServiceProvider();
            _persistDataAppService = serviceProvider.GetService<IPersistDataAppService>();

            // Rabbit
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


                var consumer = new EventingBasicConsumer(chanel);
                consumer.Received += Consumer_Received;
                chanel.BasicConsume(queue: "",
                    autoAck: true,
                    consumer: consumer);

                Console.WriteLine("Aguardando mensagem...");
                Console.WriteLine("Precione uma tecla para sair");
                Console.ReadKey();
            }
        }

        private static void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var resultString = Encoding.UTF8.GetString(e.Body);
            var result = JsonConvert.DeserializeObject<Rootobject>(resultString);

            _persistDataAppService.PersistData(new PersistDataViewModel()
            {
                Data = result
            }, (string error) => Console.WriteLine("[ERRO] {0}",error));

            Console.WriteLine(string.Format("Mensagem recebida:"));
      
        }


    }
}

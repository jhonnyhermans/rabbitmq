using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace JH.RabbitMq.Publisher.Config
{
    public class RabbitMQConfigurations
    {
        public static class Factory
        {
            public static RabbitMQConfigurations Create()
            {
                var Cconfiguration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

                var s = Cconfiguration.GetSection("RabbitMqConfigurations");
                var rabbitMQConfigurations = new RabbitMQConfigurations() {
                        HostName = s["HostName"],
                        Port = Convert.ToInt32(s["Port"]),
                        UserName = s["UserName"],
                        PassWord = s["PassWord"],

                };

                return rabbitMQConfigurations;
            }
        }

        private RabbitMQConfigurations()
        {
 
        }
        public string HostName { get; internal set; }
        public string UserName { get; internal set; }
        public string PassWord { get; internal set; }
        public int Port { get; internal set; }
    }
}

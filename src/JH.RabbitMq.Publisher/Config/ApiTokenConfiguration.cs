using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JH.RabbitMq.Publisher.Config
{
    public class ApiTokenConfiguration
    {

        public static class Factory
        {
            public static ApiTokenConfiguration Create()
            {
                var Cconfiguration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

                var s = Cconfiguration.GetSection("ApiTokenConfiguration");
                var apiTokenConfiguration = new ApiTokenConfiguration()
                {
                    Token = s["Token"],
                    Locale = s["Locale"]
                };

                return apiTokenConfiguration;
            }
        }

        public string Token { get; set; }
        public string Locale { get; internal set; }
    }
}

﻿using JH.RabbitMq.Infra.CrossCutting.IoC;
using Microsoft.Extensions.DependencyInjection;
namespace JH.RabbitMq.Publisher.Config
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddDIConfiguration(this IServiceCollection services)
        {
            BootStrapper.RegisterServices(services);
            return services;
        }
    }


}

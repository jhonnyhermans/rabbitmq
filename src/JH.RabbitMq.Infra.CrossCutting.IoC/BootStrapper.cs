
using JH.RabbitMq.Application.Services;
using JH.RabbitMq.Application.Services.Interfaces;
using JH.RabbitMq.Domain.Repository;
using JH.RabbitMq.Domain.Services;
using JH.RabbitMq.Domain.Services.Interfaces;
using JH.RabbitMq.Domain.UoW;
using JH.RabbitMq.Infra.Data.Context;
using JH.RabbitMq.Infra.Data.Repository;
using JH.RabbitMq.Infra.Data.UoW;
using Microsoft.Extensions.DependencyInjection;

namespace JH.RabbitMq.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application - Service
            services.AddScoped<ICollectDataAppService, CollectDataAppService>();
            services.AddScoped<IPersistDataAppService, PersistDataAppService>();

            // Domain - Services
            services.AddScoped<ITemperatureDataStorageService, TemperatureDataStorageService>();

            // Infra - Data
            services.AddScoped<ISomeDataRepository, SomeDataRepository>();
            services.AddScoped<ITemperatureDataStorageRepository, TemperatureDataStorage>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<SomeDataContext>();
        }

    }
}

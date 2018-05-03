using JH.RabbitMq.Domain.Repository;
using JH.RabbitMq.Domain.Services.Interfaces;

namespace JH.RabbitMq.Domain.Services
{
    public class TemperatureDataStorageService : ITemperatureDataStorageService
    {
        private readonly ITemperatureDataStorageRepository _temperatureDataStorageRepository;

        public TemperatureDataStorageService(ITemperatureDataStorageRepository temperatureDataStorageRepository)
        {
            _temperatureDataStorageRepository = temperatureDataStorageRepository;
        }
        public void Add(TemperatureDataStorage data)
        {
            _temperatureDataStorageRepository.Add(data);
        }
    }
}

namespace JH.RabbitMq.Domain.Services.Interfaces
{
    public interface ITemperatureDataStorageService
    {
        void Add(TemperatureDataStorage historic);
    }
}

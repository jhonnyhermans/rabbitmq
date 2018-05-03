using System;

namespace JH.RabbitMq.Domain
{
    public class TemperatureDataStorage
    {
   
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }

        public DateTime Date { get; private set; }

        public decimal RainPrecipitation { get; private set; }
        public decimal Temperature { get; private set; }

        public static class Factory
        {
            public static TemperatureDataStorage CreateNew(string name, string state, 
                string country, DateTime date, decimal rainPrecipitation, decimal temperatureMin)
            {
                return new TemperatureDataStorage()
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    State = state,
                    Country = country,
                    Date = date,
                    RainPrecipitation = rainPrecipitation,
                    Temperature = temperatureMin

                };
            }
        }

        public bool IsValid()
        {
            return true;
        }
    }


}

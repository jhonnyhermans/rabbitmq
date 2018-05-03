﻿using JH.RabbitMq.Domain;
using JH.RabbitMq.Domain.Repository;
using JH.RabbitMq.Infra.Data.Context;

namespace JH.RabbitMq.Infra.Data.Repository
{

    public class TemperatureDataStorage : RepositoryBase<Domain.TemperatureDataStorage>, ITemperatureDataStorageRepository
    {
        public TemperatureDataStorage(SomeDataContext context) : base(context)
        {
        }
    }
}

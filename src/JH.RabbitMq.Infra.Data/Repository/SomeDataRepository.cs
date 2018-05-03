using JH.RabbitMq.Domain;
using JH.RabbitMq.Domain.Repository;
using JH.RabbitMq.Infra.Data.Context;

namespace JH.RabbitMq.Infra.Data.Repository
{
    public class SomeDataRepository : RepositoryBase<SomeData>, ISomeDataRepository
    {
        public SomeDataRepository(SomeDataContext context) : base(context)
        {
        }
    }
}

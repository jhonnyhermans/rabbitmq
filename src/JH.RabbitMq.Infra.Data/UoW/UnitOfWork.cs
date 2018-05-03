using JH.RabbitMq.Domain.UoW;
using JH.RabbitMq.Infra.Data.Context;

namespace JH.RabbitMq.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly SomeDataContext _context;

        public UnitOfWork(SomeDataContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

     
    }
}

using System;

namespace JH.RabbitMq.Domain.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    
    }
}

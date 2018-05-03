using System.Collections.Generic;

namespace JH.RabbitMq.Domain.Core.Repository
{
    public interface IRepositoryBase<T> where T :class
    {
        IEnumerable<T> GetAll();
        T Insert(T entity);
    }
}

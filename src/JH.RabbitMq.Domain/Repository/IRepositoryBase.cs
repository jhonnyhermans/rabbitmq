using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JH.RabbitMq.Domain.Repository
{
    public interface IRepositoryBase<T> : IDisposable where T :class
    {
        IEnumerable<T> GetAll();
        void Add(T entity);

        Task<IEnumerable<T>> GetAllAsync();
        Task InsertAsync(T entity);
    }
}

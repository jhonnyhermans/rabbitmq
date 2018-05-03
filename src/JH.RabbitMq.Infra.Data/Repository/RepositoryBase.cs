using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JH.RabbitMq.Domain.Repository;
using JH.RabbitMq.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace JH.RabbitMq.Infra.Data.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {

        protected SomeDataContext Db;
        protected DbSet<T> DbSet;
        protected RepositoryBase(SomeDataContext context)
        {
            Db = context;
            DbSet = Db.Set<T>();
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public void Add(T entity)
        {
             DbSet.Add(entity);
        }

        public async Task InsertAsync(T entity)
        {
            await DbSet.AddAsync(entity);
           
        }
    }
}

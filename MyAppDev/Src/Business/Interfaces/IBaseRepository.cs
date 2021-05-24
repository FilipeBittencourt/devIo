using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        Task Create(TEntity entity);
        
        Task<TEntity> GetById(Guid id);
        
        Task<List<TEntity>> GetAll();
        
        Task Update(TEntity entity);

        Task Delete(TEntity entity);

        Task Remove(Guid id);

        Task<IEnumerable<TEntity>> List(Expression<Func<TEntity, bool>> predicate);

        Task<int> SaveChanges();
    }
}

using Business.Interfaces;
using Business.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Repository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity, new()
    {
        protected readonly AppDevIoDbContext DbContext;

        protected readonly DbSet<TEntity> DbSet;

        public BaseRepository(AppDevIoDbContext Db)
        {
            DbContext = Db;
            DbSet     = Db.Set<TEntity>();
        }

        #region Get
        public virtual async Task<List<TEntity>> GetAll()
        {         
            return await DbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {         
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> List(Expression<Func<TEntity, bool>> predicate)
        {            
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }
        #endregion


        #region Create
        public virtual async Task Create(TEntity entity)
        {            
            DbSet.Add(entity);
            await SaveChanges();
        }
        #endregion

        #region Update
        public virtual async Task Update(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }
        #endregion

        #region Delete
        public virtual async Task Delete(TEntity entity)
        {
            entity.Deleted = true;
            DbSet.Update(entity);
            await SaveChanges();
        }
        #endregion


        #region Delete
        public virtual async Task Remove(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }
        #endregion

        public async Task<int> SaveChanges()
        {
            return await DbContext.SaveChangesAsync();
        }

        public async void Dispose()
        {
            DbContext?.Dispose();
            //throw new NotImplementedException();
        }
    }
}

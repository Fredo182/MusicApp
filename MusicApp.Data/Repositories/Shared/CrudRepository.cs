using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicApp.Data.Repositories.Interfaces.Shared;

namespace MusicApp.Data.Repositories.Shared
{
    public class CrudRepository<TEntity> : ReadRepository<TEntity>, ICrudRepository<TEntity> where TEntity : class
    {
        public CrudRepository(DbContext context) : base(context){}

        public virtual void Delete(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }

            dbSet.Remove(entity);
        }

        public virtual void Delete(params object[] id)
        {
            TEntity entity = dbSet.Find(id);
            Delete(entity);
        }

        public virtual void DeleteRange(IEnumerable<TEntity> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public virtual async Task DeleteRangeAsync(IEnumerable<Expression<Func<TEntity, bool>>> predicates)
        {
            var entities = await GetAsync(predicates);
            dbSet.RemoveRange(entities);
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await dbSet.AddRangeAsync(entities);
            return entities;
        }

        public virtual TEntity Update(TEntity entity)
        {
            dbSet.Update(entity);
            return entity;
        }

        public virtual IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entities)
        {
            dbSet.UpdateRange(entities);
            return entities;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicApp.Data.Repositories.Interfaces.Shared;

namespace MusicApp.Data.Repositories.Shared
{
    public class ReadRepository<TEntity> : Repository<TEntity>, IReadRepository<TEntity> where TEntity : class
    {
        public ReadRepository(DbContext context) : base(context){}

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "", bool tracking = true)
        {
            IQueryable<TEntity> query = this.dbSet;

            // Apply filtering
            if (predicate != null)
                query = query.Where(predicate);

            // Add Include related data
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    query = query.Include(includeProperty);
            }

            // Apply orderBy
            if (orderBy != null)
            {
                if (tracking)
                    return await orderBy(query).ToListAsync();
                else
                    return await orderBy(query).AsNoTracking().ToListAsync();
            }
            else
            {
                if (tracking)
                    return await query.ToListAsync();
                else
                    return await query.AsNoTracking().ToListAsync();
            }
        }

        public async Task<TEntity> GetByIdAsync(params object[] id)
        {
            return await dbSet.FindAsync(id);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool tracking = true)
        {
            if (tracking)
                return dbSet.Where(predicate);
            else
                return dbSet.AsNoTracking().Where(predicate);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, bool tracking = true)
        {
            if (tracking)
                return await dbSet.SingleOrDefaultAsync(predicate);
            else
                return await dbSet.AsNoTracking().SingleOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetWithRawSQLAsync(string query, params object[] parameters)
        {
            return await dbSet.FromSqlRaw(query, parameters).ToListAsync();
        }
    }
}

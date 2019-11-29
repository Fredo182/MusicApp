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

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = this.dbSet;

            // Apply filtering
            if (filter != null)
                query.Where(filter);

            // Add Include related data
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    query.Include(includeProperty);
            }

            // Apply orderBy
            if (orderBy != null)
                return await orderBy(query).ToListAsync();
            else
                return await query.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(params object[] id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetWithRawSQLAsync(string query, params object[] parameters)
        {
            return await dbSet.FromSqlRaw(query, parameters).ToListAsync();
        }
    }
}

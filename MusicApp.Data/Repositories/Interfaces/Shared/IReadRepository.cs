using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MusicApp.Data.Repositories.Interfaces.Shared
{
    public interface IReadRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        //READ
        Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        Task<TEntity> GetByIdAsync(params object[] id);

        Task<IEnumerable<TEntity>> GetWithRawSQLAsync(
            string query,
            params object[] parameters);
    }
}

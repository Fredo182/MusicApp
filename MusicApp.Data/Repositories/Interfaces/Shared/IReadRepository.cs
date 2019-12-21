using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MusicApp.Data.Domain.Queries.Shared;
using MusicApp.Data.Domain.Shared;
using MusicApp.Data.Helpers;

namespace MusicApp.Data.Repositories.Interfaces.Shared
{
    public interface IReadRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        //READ
        Task<IEnumerable<TEntity>> GetAsync(IEnumerable<Expression<Func<TEntity, bool>>> filters = null, IEnumerable<IOrderByClause<TEntity>> orderBy = null, string includeProperties = "", bool tracking=true);
        Task<PagedResult<TEntity>> GetPagedAsync(Pagination pagination, IEnumerable<Expression<Func<TEntity, bool>>> filters = null, IEnumerable<IOrderByClause<TEntity>> orderBy = null, string includeProperties = "", bool tracking = true);
        Task<TEntity> GetByIdAsync(params object[] id);
        Task<TEntity> GetOneAsync(IEnumerable<Expression<Func<TEntity, bool>>> filters = null, string includeProperties = "", bool tracking=true);
        Task<TEntity> GetFirstAsync(IEnumerable<Expression<Func<TEntity, bool>>> filters = null, IEnumerable<IOrderByClause<TEntity>> orderBy = null, string includeProperties = "", bool tracking = true);
        Task<int> GetCountAsync(IEnumerable<Expression<Func<TEntity, bool>>> filters = null, bool tracking = true);
        Task<bool> GetExistsAsync(IEnumerable<Expression<Func<TEntity, bool>>> filters = null, bool tracking = true);
        Task<IEnumerable<TEntity>> GetWithRawSQLAsync(string query, params object[] parameters);
    }
}

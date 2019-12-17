﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MusicApp.Data.Domain.Queries.Shared;
using MusicApp.Data.Domain.Shared;

namespace MusicApp.Data.Repositories.Interfaces.Shared
{
    public interface IReadRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        //READ
        Task<IEnumerable<TEntity>> GetAsync(
            IEnumerable<Expression<Func<TEntity, bool>>> filters = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "",
            bool tracking=true
        );

        Task<PagedResult<TEntity>> GetPagedAsync(
            Pagination pagination,
            IEnumerable<Expression<Func<TEntity, bool>>> filters = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "",
            bool tracking = true
        );

        Task<TEntity> GetByIdAsync(params object[] id);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool tracking=true);

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, bool tracking=true);
        
        Task<IEnumerable<TEntity>> GetWithRawSQLAsync(
            string query,
            params object[] parameters);
    }
}

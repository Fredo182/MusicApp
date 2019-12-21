﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicApp.Data.Domain.Queries.Shared;
using MusicApp.Data.Domain.Shared;
using MusicApp.Data.Helpers;
using MusicApp.Data.Repositories.Interfaces.Shared;

namespace MusicApp.Data.Repositories.Shared
{
    public class ReadRepository<TEntity> : Repository<TEntity>, IReadRepository<TEntity> where TEntity : class
    {
        public ReadRepository(DbContext context) : base(context){}

        public async Task<IEnumerable<TEntity>> GetAsync(IEnumerable<Expression<Func<TEntity, bool>>> filters = null, IEnumerable<IOrderByClause<TEntity>> orderBy = null, string includeProperties = "", bool tracking = true)
        {
            IQueryable<TEntity> query = this.dbSet;

            // Apply filtering
            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    query = query.Where(filter);
                }
            }

            // Add Include related data
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    query = query.Include(includeProperty);
            }

            // Apply orderBy
            if (orderBy != null)
            {
                bool isFirstSort = true;
                orderBy.ToList().ForEach(o =>
                {
                    query = o.ApplySort(query, isFirstSort);
                    isFirstSort = false;
                });
            }

            if (tracking)
                return await query.ToListAsync();
            else
                return await query.AsNoTracking().ToListAsync();
        }

        public async Task<PagedResult<TEntity>> GetPagedAsync(Pagination pagination, IEnumerable<Expression<Func<TEntity, bool>>> filters = null, IEnumerable<IOrderByClause<TEntity>> orderBy = null, string includeProperties = "", bool tracking = true)
        {
            var result = new PagedResult<TEntity>();
            result.PageState.PageNumber = pagination.PageNumber;
            result.PageState.PageSize = pagination.PageSize;


            IQueryable<TEntity> query = this.dbSet;

            // Apply filtering
            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    query = query.Where(filter);
                }
            }

            // Add Include related data
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    query = query.Include(includeProperty);
            }

            // Set skip for pagination
            var skip = 0;
            var take = 0;
            if (pagination != null)
            {
                skip = (pagination.PageNumber - 1) * pagination.PageSize;
                take = pagination.PageSize;
            }

            result.PageState.Total = query.Count();
            var pageCount = (double)result.PageState.Total / pagination.PageSize;
            result.PageState.TotalPages = (int)Math.Ceiling(pageCount);

            // Apply orderBy
            if (orderBy != null)
            {
                bool isFirstSort = true;
                orderBy.ToList().ForEach(o =>
                {
                    query = o.ApplySort(query, isFirstSort);
                    isFirstSort = false;
                });
            }
            
            if (tracking)
                result.Result = await query.Skip(skip).Take(take).ToListAsync();
            else
                result.Result =  await query.AsNoTracking().Skip(skip).Take(take).ToListAsync();
            

            return result;
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

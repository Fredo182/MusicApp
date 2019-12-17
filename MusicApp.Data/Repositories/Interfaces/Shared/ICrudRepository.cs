using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MusicApp.Data.Repositories.Interfaces.Shared
{
    public interface ICrudRepository<TEntity> : IReadRepository<TEntity> where TEntity : class
    {
        //CREATE
        Task<TEntity> AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);

        //UPDATE
        TEntity Update(TEntity entity);
        IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entities);

        //DELETE
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
        Task DeleteRangeAsync(IEnumerable<Expression<Func<TEntity, bool>>> predicates);
        void Delete(params object[] id);
    }
}

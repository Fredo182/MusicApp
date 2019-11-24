using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicApp.Core.Repositories.Shared
{
    public interface ICrudRepository<TEntity> : IReadRepository<TEntity> where TEntity : class
    {
        //CREATE
        Task<TEntity> InsertAsync(TEntity entity);
        Task<IEnumerable<TEntity>> InsertRangeAsync(IEnumerable<TEntity> entities);

        //UPDATE
        TEntity Update(TEntity entity);
        IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entities);

        //DELETE
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
        void Delete(object id);
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using MusicApp.Core.Repositories.Shared;

namespace MusicApp.Data.Repositories.Shared
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext context;

        protected readonly DbSet<TEntity> dbSet;

        protected Repository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
    }
}

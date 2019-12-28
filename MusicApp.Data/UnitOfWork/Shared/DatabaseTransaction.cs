using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MusicApp.Data.UnitOfWork.Shared.Interfaces;

namespace MusicApp.Data.UnitOfWork.Shared
{
    public class DatabaseTransaction : IDatabaseTransaction
    {
        private IDbContextTransaction _transaction;

        public DatabaseTransaction(DbContext context)
        {
            _transaction = context.Database.BeginTransaction();
        }

        public Task CommitAsync()
        {
            return _transaction.CommitAsync();
        }

        public Task RollbackAsync()
        {
            return _transaction.RollbackAsync();
        }

        public void Dispose()
        {
            _transaction.Dispose();
        }
    }
}

using System;
using System.Threading.Tasks;

namespace MusicApp.Data.UnitOfWork.Shared.Interfaces
{
    // https://entityframework.net/knowledge-base/39906474/how-can-i-implement-a-transaction-for-my-repositories-with-entity-framework-

    public interface IDatabaseTransaction : IDisposable
    {
        Task CommitAsync();
        Task RollbackAsync();
    }
}

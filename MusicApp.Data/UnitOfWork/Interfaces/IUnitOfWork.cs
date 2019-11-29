using System;
using System.Threading.Tasks;

namespace MusicApp.Data.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // Add All interface repositories here
        // ...
        // ...
        // e.g.

        // IArtistRepository Artists { get; }
        // IAlbumRepository Orders { get; }

        Task<int> CommitAsync();
    }
}

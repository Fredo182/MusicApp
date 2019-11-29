using System;
using System.Threading.Tasks;
using MusicApp.Data.Repositories.Interfaces;

namespace MusicApp.Data.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // Add All interface repositories here
        // ...
        // ...
        // e.g.

        IAlbumRepository Albums { get; }
        IArtistGenreRepository ArtistGenres { get; }
        IArtistRepository Artists { get; }
        IGenreRepository Genres { get; }
        ISongRepository Songs { get; }
        
        Task<int> CommitAsync();
    }
}

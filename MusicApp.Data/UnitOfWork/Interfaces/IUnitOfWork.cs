using System;
using System.Threading.Tasks;
using MusicApp.Data.Repositories.Interfaces;
using MusicApp.Data.UnitOfWork.Shared.Interfaces;

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
        IPlaylistRepository Playlists { get; }

        IDatabaseTransaction BeginTransaction();
        Task<int> CommitAsync();

    }
}

using System;
using System.Threading.Tasks;
using MusicApp.Data.Repositories;
using MusicApp.Data.Repositories.Interfaces;
using MusicApp.Data.UnitOfWork.Interfaces;
using MusicApp.Data.UnitOfWork.Shared;
using MusicApp.Data.UnitOfWork.Shared.Interfaces;

namespace MusicApp.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        // DbContext
        private readonly MusicAppDbContext _context;

        // Repositories
        private AlbumRepository _albumRepository;
        private ArtistGenreRepository _artistgenreRepository;
        private ArtistRepository _artistRepository;
        private GenreRepository _genreRepository;
        private SongRepository _songRepository;
        private PlaylistRepository _playlistRepository;

        public UnitOfWork(MusicAppDbContext context)
        {
            this._context = context;
        }

        public IAlbumRepository Albums => _albumRepository ??= new AlbumRepository(_context);

        public IArtistGenreRepository ArtistGenres => _artistgenreRepository ??= new ArtistGenreRepository(_context);

        public IArtistRepository Artists => _artistRepository ??= new ArtistRepository(_context);

        public IGenreRepository Genres => _genreRepository ??= new GenreRepository(_context);

        public ISongRepository Songs => _songRepository ??= new SongRepository(_context);

        public IPlaylistRepository Playlists => _playlistRepository ??= new PlaylistRepository(_context);

        public IDatabaseTransaction BeginTransaction()
        {
            return new DatabaseTransaction(_context);
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MusicApp.Data.Domain.Authorization;
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

        // Identity Stores
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<User> _signInManager;

        // Repositories
        private UserRepository _userRepository;
        private RoleRepository _roleRepository;

        private AlbumRepository _albumRepository;
        private ArtistGenreRepository _artistgenreRepository;
        private ArtistRepository _artistRepository;
        private GenreRepository _genreRepository;
        private SongRepository _songRepository;
        private PlaylistRepository _playlistRepository;

        public UnitOfWork(MusicAppDbContext context, UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager)
        {
            this._context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public UserManager<User> UserManager => _userManager;

        public RoleManager<Role> RoleManager => _roleManager;

        public SignInManager<User> SignInManager => _signInManager;

        public IUserRepository Users => _userRepository ??= new UserRepository(_context);

        public IRoleRepository Roles => _roleRepository ??= new RoleRepository(_context);

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

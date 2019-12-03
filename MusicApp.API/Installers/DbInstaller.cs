using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicApp.API.Installers.Interfaces;
using MusicApp.Data;
using MusicApp.Data.UnitOfWork;
using MusicApp.Data.UnitOfWork.Interfaces;
using MusicApp.Services.Services;
using MusicApp.Services.Services.Interfaces;

namespace MusicApp.API.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            // Database
            var connection = configuration.GetConnectionString("MusicApp_Dev");

            services.AddDbContextPool<MusicAppDbContext>( options =>
                options.UseSqlServer( connection , x => x.MigrationsAssembly("MusicApp.Data"))
            );

            // Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Services
            services.AddScoped<IAlbumService, AlbumService>();
            services.AddScoped<IArtistGenreService, ArtistGenreService>();
            services.AddScoped<IArtistService, ArtistService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<ISongService, SongService>();
            services.AddScoped<IPlaylistService, PlaylistService>();

        }
    }
}

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
            services.AddTransient<IAlbumService, AlbumService>();
            services.AddTransient<IArtistGenreService, ArtistGenreService>();
            services.AddTransient<IArtistService, ArtistService>();
            services.AddTransient<IGenreService, GenreService>();
            services.AddTransient<ISongService, SongService>();

        }
    }
}

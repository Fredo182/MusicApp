using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicApp.API.Installers.Interfaces;
using MusicApp.API.Security.TokenProviders;
using MusicApp.Data;
using MusicApp.Data.Domain.Authorization;
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

            // Add Identity Services
            services.AddIdentity<User, Role>(options =>
            {

                //User Options
                options.User.RequireUniqueEmail = true;

                //Password Options
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;

                //Account Lockout Options
                //options.Lockout.AllowedForNewUsers = true;
                //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                //options.Lockout.MaxFailedAccessAttempts = 5;

                //SingIn options
                options.SignIn.RequireConfirmedEmail = true;

                //Token Providers
                options.Tokens.EmailConfirmationTokenProvider = "EmailConfirmationTokenProvider";
                options.Tokens.PasswordResetTokenProvider = "PasswordResetTokenProvider";

            })
            .AddEntityFrameworkStores<MusicAppDbContext>()
            .AddDefaultTokenProviders()
            .AddTokenProvider<EmailConfirmationTokenProvider<User>>("EmailConfirmationTokenProvider")
            .AddTokenProvider<PasswordResetTokenProvider<User>>("PasswordResetTokenProvider");

            services.Configure<EmailConfirmationTokenProviderOptions>(o =>
            {
                o.TokenLifespan = TimeSpan.FromDays(5);
            });

            services.Configure<PasswordResetTokenProviderOptions>(o =>
            {
                o.TokenLifespan = TimeSpan.FromHours(1);
            });


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

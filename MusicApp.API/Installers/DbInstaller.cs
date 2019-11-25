using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicApp.API.Installers.Interfaces;
using MusicApp.Data;

namespace MusicApp.API.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            // Add Entity framework services here
            // ...
            // ...
            var connection = configuration.GetConnectionString("MusicApp_Dev");

            services.AddDbContextPool<MusicAppDbContext>( options =>
                options.UseSqlServer( connection , x => x.MigrationsAssembly("MusicApp.Data"))
            ); 

        }
    }
}

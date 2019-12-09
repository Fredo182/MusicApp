using System;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicApp.API.Installers.Interfaces;
using MusicApp.API.Mapping;
using MusicApp.Services.Mapping;

namespace MusicApp.API.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            // Add AutoMapper
            services.AddAutoMapper(
                new Assembly[] {
                    typeof(ModelToResponseProfile).GetTypeInfo().Assembly,
                    typeof(RequestToModelProfile).GetTypeInfo().Assembly,
                    typeof(DomainToModelProfile).GetTypeInfo().Assembly,
                    typeof(ModelToDomainProfile).GetTypeInfo().Assembly
                }
            );

        }
    }
}

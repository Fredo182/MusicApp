using System;
using System.Reflection;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicApp.API.Filters;
using MusicApp.API.Installers.Interfaces;
using MusicApp.API.Mapping;
using MusicApp.Services.Mapping;

namespace MusicApp.API.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddControllers(options =>
                {
                    options.Filters.Add<ValidationFilter>();
                })
                .AddFluentValidation( config => {
                    config.RegisterValidatorsFromAssemblyContaining<Startup>();
                    config.ImplicitlyValidateChildProperties = true;
                });

            // Add assemblies to automapper
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            services.AddAutoMapper(assemblies);

        }
    }
}

using System;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicApp.API.Installers.Interfaces;
using MusicApp.API.Mapping;
using MusicApp.API.Services;
using MusicApp.API.Services.Interfaces;
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

            // UriService
            services.AddSingleton<IUriService>(provider =>
            {
                var accessor = provider.GetRequiredService<IHttpContextAccessor>();
                var request = accessor.HttpContext.Request;
                var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent(), "/");
                return new UriService(absoluteUri);
            });
        }
    }
}

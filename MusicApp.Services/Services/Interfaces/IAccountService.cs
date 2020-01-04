using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MusicApp.Services.Models.Authorization;
using MusicApp.Services.Services.Shared;

namespace MusicApp.Services.Services.Interfaces
{
    public interface IAccountService
    {
        Task<ServiceResponse> RegisterAsync(UserModel user, string password);
    }
}

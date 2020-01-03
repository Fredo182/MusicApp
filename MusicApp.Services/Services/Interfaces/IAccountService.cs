using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MusicApp.Services.Models.Authorization;

namespace MusicApp.Services.Services.Interfaces
{
    public interface IAccountService
    {
        Task<IdentityResult> RegisterAsync(UserModel user, string password);
    }
}

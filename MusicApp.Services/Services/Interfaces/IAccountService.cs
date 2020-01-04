using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MusicApp.Services.Models.Authorization;
using MusicApp.Services.Services.Responses;

namespace MusicApp.Services.Services.Interfaces
{
    public interface IAccountService
    {
        Task<AccountResponse> RegisterAsync(UserModel user, string password);
        Task<AccountResponse<string>> PasswordSignInAsync(string email, string password, bool persistent, bool lockout = false, bool confirmEmail = true);
        Task<AccountResponse> ConfirmEmailAsync(int userid, string token);
        Task<AccountResponse> ForgotPasswordAsync(string email);
        Task<AccountResponse> ResetPasswordAsync(string email, string token, string password);
    }
}

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MusicApp.Services.Models.Authorization;
using MusicApp.Services.Services.Responses;

namespace MusicApp.Services.Services.Interfaces
{
    public interface IAccountService
    {
        Task<AccountServiceResponse> RegisterAsync(UserModel user, string password);
        Task<AccountServiceResponse> LoginAsync(string email, string password, bool confirmEmail = true);
        Task<AccountServiceResponse> RefreshAsync(string accessToken, string refreshToken);
        Task<AccountServiceResponse> ConfirmEmailAsync(int userid, string token);
        Task<AccountServiceResponse> ForgotPasswordAsync(string email);
        Task<AccountServiceResponse> ResetPasswordAsync(string email, string token, string password);
        Task<AccountServiceResponse> ChangePasswordAsync(string email, string currentPassword, string newPassword);
    }
}

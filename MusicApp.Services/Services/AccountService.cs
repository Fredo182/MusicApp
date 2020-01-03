using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MusicApp.Data.Domain.Authorization;
using MusicApp.Services.Models.Authorization;
using MusicApp.Services.Services.Interfaces;

namespace MusicApp.Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly ILogger<AccountService> _logger;


        public AccountService(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager, IMapper mapper, ILogger<AccountService> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IdentityResult> RegisterAsync(UserModel user, string password)
        {
            var u = _mapper.Map<User>(user);
            IdentityResult r = await _userManager.CreateAsync(u, password);

            if (r.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(u);
                _logger.LogInformation("Email Confirmation Token: " + token + " UserId: " + u.Id);

                //TODO create a link for the email with token and userid
            }
            return r;
        }

        public async Task<SignInResult> PasswordSignInAsync(string email, string password, bool persistent, bool lockout, bool confirmEmail)
        {
            if (confirmEmail)
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user != null && !user.EmailConfirmed && (await _userManager.CheckPasswordAsync(user, password)))
                    //"User needs to confirm email"
                    return null;
            }

            SignInResult r = await _signInManager.PasswordSignInAsync(email, password, persistent, lockout);
            return r;
        }

        public async Task<IdentityResult> ConfirmEmailAsync(UserModel user, string token)
        {
            var u = _mapper.Map<User>(user);
            u = await _userManager.FindByEmailAsync(user.Email);

            if (u == null)
                return null;

            IdentityResult r = await _userManager.ConfirmEmailAsync(u, token);
            return r;
        }

        public async Task ForgotPasswordAsync(string email)
        {
            var u = await _userManager.FindByEmailAsync(email);

            if (u != null && await _userManager.IsEmailConfirmedAsync(u))
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(u);
                _logger.LogInformation("Password Reset Token: " + token + " Email: " + email);

                //TODO create a link for the email with password token and email
            }
        }

        public async Task<IdentityResult> ResetPasswordAsync(string email, string token, string password)
        {
            var u = await _userManager.FindByEmailAsync(email);

            if (u == null)
                return null;

            IdentityResult r = await _userManager.ResetPasswordAsync(u, token, password);
            return r;
        }

        // Cookie Sign In
        public async Task SignInAsync(UserModel user, bool persistent)
        {
            var u = _mapper.Map<User>(user);
            await _signInManager.SignInAsync(u, persistent);
        }

        // Cookie Sign Out
        public async Task SignOutAsync(UserModel user, bool persistent)
        {
            var u = _mapper.Map<User>(user);
            await _signInManager.SignOutAsync();
        }


    }
}

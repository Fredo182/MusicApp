using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MusicApp.Data.Domain.Authorization;
using MusicApp.Data.UnitOfWork.Interfaces;
using MusicApp.Services.Models.Authorization;
using MusicApp.Services.Services.Interfaces;
using MusicApp.Services.Services.Responses;

namespace MusicApp.Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper, IEmailService emailService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<AccountResponse> RegisterAsync(UserModel user, string password)
        {
            var u = _mapper.Map<User>(user);
            var result = await _unitOfWork.UserManager.CreateAsync(u, password);
            if (result.Succeeded)
            {
                var token = await _unitOfWork.UserManager.GenerateEmailConfirmationTokenAsync(u);
                //TODO: Fix this url
                var url = "?token=" + token + "&id" + u.Id;
                var sent = _emailService.SendConfirmEmail(u.Email, url);
                if (sent)
                {
                    await _unitOfWork.CommitAsync();
                    return new AccountResponse(){ Success = true };
                }
                else
                {
                    return new AccountResponse() { SendConfirmEmailFailed = true };
                }
            }
            else
            {
                return new AccountResponse() { Errors = result.Errors };
            }
        }

        public async Task<AccountResponse<string>> PasswordSignInAsync(string email, string password, bool persistent, bool lockout=false, bool confirmEmail=true)
        {
            
            if (confirmEmail)
            {
                var user = await _unitOfWork.UserManager.FindByEmailAsync(email);
                if (user != null && !user.EmailConfirmed && (await _unitOfWork.UserManager.CheckPasswordAsync(user, password)))
                    return new AccountResponse<string>() { EmailNotConfirmed = true };
            }

            //TODO: do the token stuff here
            //SignInResult r = await _unitOfWork.SignInManager.PasswordSignInAsync(email, password, persistent, lockout);
            return new AccountResponse<string>("token:123456789");
        }

        public async Task<AccountResponse> ConfirmEmailAsync(int userid, string token)
        {
            //User manager doesnt have int as key. It will be converted later on in the call
            var u = await _unitOfWork.UserManager.FindByIdAsync(userid.ToString());
            if (u == null)
                return new AccountResponse() { UserNotFound = true };

            IdentityResult result = await _unitOfWork.UserManager.ConfirmEmailAsync(u, token);
            if (result.Succeeded)
            {
                await _unitOfWork.CommitAsync();
                return new AccountResponse() { Success = true };
            }
            else
            {
                return new AccountResponse() { Errors = result.Errors };
            }
        }

        public async Task<AccountResponse> ForgotPasswordAsync(string email)
        {
            var u = await _unitOfWork.UserManager.FindByEmailAsync(email);
            if (u != null && await _unitOfWork.UserManager.IsEmailConfirmedAsync(u))
            {
                var token = await _unitOfWork.UserManager.GeneratePasswordResetTokenAsync(u);
                //TODO: Fix this url
                var url = "?token=" + token;
                var sent = _emailService.SendPasswordReset(u.Email, url);
                if (sent)
                {
                    await _unitOfWork.CommitAsync();
                    return new AccountResponse() { Success = true };
                }
                else
                {
                    return new AccountResponse() { SendResetPasswordFailed = true };
                }
            }
            return new AccountResponse() { Success = true };
        }

        public async Task<AccountResponse> ResetPasswordAsync(string email, string token, string password)
        {
            var u = await _unitOfWork.UserManager.FindByEmailAsync(email);
            if (u == null)
                return new AccountResponse() { UserNotFound = true };

            IdentityResult result = await _unitOfWork.UserManager.ResetPasswordAsync(u, token, password);
            if (result.Succeeded)
            {
                await _unitOfWork.CommitAsync();
                return new AccountResponse() { Success = true };
            }
            else
            {
                return new AccountResponse() { Errors = result.Errors };
            }
        }

        //// Cookie Sign In
        //public async Task SignInAsync(UserModel user, bool persistent)
        //{
        //    var u = _mapper.Map<User>(user);
        //    await _signInManager.SignInAsync(u, persistent);
        //}

        //// Cookie Sign Out
        //public async Task SignOutAsync(UserModel user, bool persistent)
        //{
        //    var u = _mapper.Map<User>(user);
        //    await _signInManager.SignOutAsync();
        //}


    }
}

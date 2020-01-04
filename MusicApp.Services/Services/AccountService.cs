using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MusicApp.Data.Domain.Authorization;
using MusicApp.Data.UnitOfWork.Interfaces;
using MusicApp.Services.Models.Authorization;
using MusicApp.Services.Services.Interfaces;
using MusicApp.Services.Services.Shared;

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

        public async Task<ServiceResponse> RegisterAsync(UserModel user, string password)
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
                    return new ServiceResponse();
                }
                else
                {
                    return new ServiceResponse("Confirmation Email failed to send.");
                }
            }
            else
            {
                return new ServiceResponse(result.Errors.Select(e => e.Description).ToList());
            }
        }

        public async Task<SignInResult> PasswordSignInAsync(string email, string password, bool persistent, bool lockout=false, bool confirmEmail=true)
        {
            if (confirmEmail)
            {
                var user = await _unitOfWork.UserManager.FindByEmailAsync(email);
                if (user != null && !user.EmailConfirmed && (await _unitOfWork.UserManager.CheckPasswordAsync(user, password)))
                    return null;
            }

            SignInResult r = await _unitOfWork.SignInManager.PasswordSignInAsync(email, password, persistent, lockout);
            return r;
        }

        public async Task<ServiceResponse> ConfirmEmailAsync(UserModel user, string token)
        {
            var u = _mapper.Map<User>(user);
            u = await _unitOfWork.UserManager.FindByEmailAsync(user.Email);
            if (u == null)
                return new ServiceResponse("User was not found");

            IdentityResult result = await _unitOfWork.UserManager.ConfirmEmailAsync(u, token);
            if (result.Succeeded)
            {
                await _unitOfWork.CommitAsync();
                return new ServiceResponse();
            }
            else
            {
                return new ServiceResponse(result.Errors.Select(e => e.Description).ToList());
            }
        }

        public async Task ForgotPasswordAsync(string email)
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
                }
            }
        }

        public async Task<ServiceResponse> ResetPasswordAsync(string email, string token, string password)
        {
            var u = await _unitOfWork.UserManager.FindByEmailAsync(email);
            if (u == null)
                return new ServiceResponse("User was not found");

            IdentityResult result = await _unitOfWork.UserManager.ResetPasswordAsync(u, token, password);
            if (result.Succeeded)
            {
                await _unitOfWork.CommitAsync();
                return new ServiceResponse();
            }
            else
            {
                return new ServiceResponse(result.Errors.Select(e => e.Description).ToList());
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

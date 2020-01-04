using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MusicApp.Data.Domain.Authorization;
using MusicApp.Data.UnitOfWork.Interfaces;
using MusicApp.Services.Models.Authorization;
using MusicApp.Services.Security.Options;
using MusicApp.Services.Services.Interfaces;
using MusicApp.Services.Services.Responses;

namespace MusicApp.Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly JwtSettings _jwtSettings;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper, IEmailService emailService, JwtSettings jwtSettings)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailService = emailService;
            _jwtSettings = jwtSettings;
        }

        public async Task<AccountResponse> RegisterAsync(UserModel user, string password)
        {
            var u = _mapper.Map<User>(user);
            //Do I need to check if the emal already exists?
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

        private SecurityToken GetToken(string email, int userid)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, email),
                    new Claim("id", userid.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return token;
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

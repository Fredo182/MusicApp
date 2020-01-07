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

        public async Task<AccountServiceResponse> RegisterAsync(UserModel user, string password)
        {
            var u = _mapper.Map<User>(user);
            var result = await _unitOfWork.UserManager.CreateAsync(u, password);
            if (result.Succeeded)
            {
                await _unitOfWork.CommitAsync();
                var token = await _unitOfWork.UserManager.GenerateEmailConfirmationTokenAsync(u);
                //TODO: Fix this url
                var url = "?token=" + token + "&id" + u.Id;
                var sent = _emailService.SendConfirmEmail(u.Email, url);
                return new AccountServiceResponse(){ Success = true };
            }
            else
            {
                return new AccountServiceResponse() { Errors = result.Errors };
            }
        }

        public async Task<AccountServiceResponse> LoginAsync(string email, string password, bool confirmEmail=true)
        {

            var user = await _unitOfWork.UserManager.FindByEmailAsync(email);
            if (confirmEmail)
            {
                if (user != null && !user.EmailConfirmed && (await _unitOfWork.UserManager.CheckPasswordAsync(user, password)))
                    return new AccountServiceResponse() { EmailNotConfirmed = true };
            }

            var userHasValidPassword = await _unitOfWork.UserManager.CheckPasswordAsync(user, password);

            if (!userHasValidPassword || user == null)
                return new AccountServiceResponse() { Success = false };

            var token = GenerateTokenForUser(user);

            return new AccountServiceResponse(token);
        }

        public async Task<AccountServiceResponse> ConfirmEmailAsync(int userid, string token)
        {
            //User manager doesnt have int as key. It will be converted later on in the call
            var u = await _unitOfWork.UserManager.FindByIdAsync(userid.ToString());
            if (u == null)
                return new AccountServiceResponse() { Success = false };

            IdentityResult result = await _unitOfWork.UserManager.ConfirmEmailAsync(u, token);
            if (result.Succeeded)
            {
                await _unitOfWork.CommitAsync();
                return new AccountServiceResponse() { Success = true };
            }
            else
            {
                return new AccountServiceResponse() { Errors = result.Errors };
            }
        }

        public async Task<AccountServiceResponse> ForgotPasswordAsync(string email)
        {
            var u = await _unitOfWork.UserManager.FindByEmailAsync(email);
            if (u != null && await _unitOfWork.UserManager.IsEmailConfirmedAsync(u))
            {
                var token = await _unitOfWork.UserManager.GeneratePasswordResetTokenAsync(u);
                //TODO: Fix this url
                var url = "?token=" + token;
                var sent = _emailService.SendPasswordReset(u.Email, url);
                return new AccountServiceResponse() { Success = true };
            }
            return new AccountServiceResponse() { Success = true };
        }

        public async Task<AccountServiceResponse> ResetPasswordAsync(string email, string token, string password)
        {
            var u = await _unitOfWork.UserManager.FindByEmailAsync(email);
            if (u == null)
                return new AccountServiceResponse() { Success = false };

            IdentityResult result = await _unitOfWork.UserManager.ResetPasswordAsync(u, token, password);
            if (result.Succeeded)
            {
                await _unitOfWork.CommitAsync();
                return new AccountServiceResponse() { Success = true };
            }
            else
            {
                return new AccountServiceResponse() { Errors = result.Errors };
            }
        }

        private string GenerateTokenForUser(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim("id", user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}

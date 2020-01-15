using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
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
        private readonly TokenValidationParameters _tokenValidationParameters;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper, IEmailService emailService, JwtSettings jwtSettings, TokenValidationParameters tokenValidationParameters)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailService = emailService;
            _jwtSettings = jwtSettings;
            _tokenValidationParameters = tokenValidationParameters;
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

            return await GenerateTokensForUser(user);
        }

        public async Task<AccountServiceResponse> RefreshAsync(string accessToken, string refreshToken)
        {
            var validatedToken = GetPrincipalFromToken(accessToken);
            if (validatedToken == null)
            {
                // Invalid Token
                return new AccountServiceResponse() { Success = false };
            }

            var expiryDateUnix = long.Parse(validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Exp).Value);
            var expiryDateTimeUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                .AddSeconds(expiryDateUnix);

            if (expiryDateTimeUtc > DateTime.UtcNow)
            {
                // Token has not expired
                return new AccountServiceResponse() { Success = false };
            }

            var jti = validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;

            var f = new List<Expression<Func<UserRefreshToken, bool>>>() { (x => x.RefreshToken == refreshToken) };
            var storedRefreshToken = await _unitOfWork.UserRefreshTokens.GetOneAsync(f, "", false);
            if (storedRefreshToken == null)
            {
                // Refresh token does not exist.
                return new AccountServiceResponse() { Success = false };
            }

            if (DateTime.UtcNow > storedRefreshToken.ExpiryDate.UtcDateTime)
            {
                // Refresh token has expired
                return new AccountServiceResponse() { Success = false };
            }

            if (storedRefreshToken.IsActive == false)
            {
                // Refresh token is not active
                return new AccountServiceResponse() { Success = false };
            }

            if (storedRefreshToken.JwtId != jti)
            {
                // Refresh token does not match Access Token
                return new AccountServiceResponse() { Success = false };
            }

            var user = await _unitOfWork.UserManager.FindByIdAsync(validatedToken.Claims.Single(x => x.Type == "id").Value);
            if (user == null)
            {
                // User not found
                return new AccountServiceResponse() { Success = false };
            }

            return await GenerateTokensForUser(user);

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

        public async Task<AccountServiceResponse> ChangePasswordAsync(string email, string currentPassword, string newPassword)
        {
            var u = await _unitOfWork.UserManager.FindByEmailAsync(email);
            if (u != null && await _unitOfWork.UserManager.CheckPasswordAsync(u, currentPassword))
            {
                IdentityResult result = await _unitOfWork.UserManager.ChangePasswordAsync(u, currentPassword, newPassword);
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
            else
            {
                return new AccountServiceResponse() { Success = false };
            }
        }

        private ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var principal = tokenHandler.ValidateToken(token, _tokenValidationParameters, out var validateToken);
                if (IsJwtWithValidSecurityAlgorithm(validateToken))
                {
                    return principal;
                }
                else
                    return null;
            }
            catch {
                return null;
            }
        }

        private bool IsJwtWithValidSecurityAlgorithm(SecurityToken validateToken)
        {
            return (validateToken is JwtSecurityToken jwtSecurityToken) && jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);
        }

        private async Task<AccountServiceResponse> GenerateTokensForUser(User user)
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
                Expires = DateTime.UtcNow.Add(_jwtSettings.AccessTokenLifetime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var refreshToken = new UserRefreshToken
            {
                RefreshToken = Guid.NewGuid().ToString(),
                JwtId = token.Id,
                UserId = user.Id,
                ExpiryDate = DateTimeOffset.UtcNow.Add(_jwtSettings.RefreshTokenLifetime)
            };

            await _unitOfWork.UserRefreshTokens.AddAsync(refreshToken);
            await _unitOfWork.CommitAsync();

            return new AccountServiceResponse(tokenHandler.WriteToken(token), refreshToken.RefreshToken);
        }

    }
}

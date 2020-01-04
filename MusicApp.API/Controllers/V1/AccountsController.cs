using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicApp.API.Contracts.V1;
using MusicApp.API.Contracts.V1.Requests.AccountsRequests;
using MusicApp.API.Contracts.V1.Requests.Queries;
using MusicApp.API.Contracts.V1.Responses.Shared;
using MusicApp.API.Helpers;
using MusicApp.Services.Models.Authorization;
using MusicApp.Services.Services.Interfaces;

namespace MusicApp.API.Controllers.V1
{
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        private readonly ILogger<AccountsController> _logger;
        

        public AccountsController(IMapper mapper, ILogger<AccountsController> logger, IAccountService accountService)
        {
            _mapper = mapper;
            _logger = logger;
            _accountService = accountService;
        }

        [HttpPost(ApiRoutes.Account.Register)]
        public async Task<IActionResult> Register([FromBody] AccountRegisterRequest request)
        {
            try
            {
                var user = _mapper.Map<UserModel>(request);
                var response = await _accountService.RegisterAsync(user, request.Password);
                if (response.Success)
                    return Ok();
                else
                    return BadRequest(new ErrorResponse(AccountErrorsToResponse.Parse(response)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse(ErrorMessages.Account.FailedRegister));
            }
        }

        //[HttpPost(ApiRoutes.Account.Login)]
        //public async Task<IActionResult> Login([FromBody] AccountLoginRequest postRequest)
        //{
        //    try
        //    {
        //        //var post = _mapper.Map<ArtistModel>(postRequest);
        //        //bool exists = await _artistService.ArtistNameExistsAsync(post);
        //        //if (exists)
        //        //    return BadRequest(new ErrorResponse(ErrorMessages.Artist.NameExists));

        //        //var artist = await _artistService.CreateArtistAsync(post);
        //        //var locationUri = ApiRoutes.Artists.Route + "/" + artist.ArtistId;
        //        //return Created(locationUri, new Response<ArtistResponse>(_mapper.Map<ArtistResponse>(artist)));
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, ErrorMessages.Account.FailedLogin);
        //        return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse(ErrorMessages.Account.FailedLogin));
        //    }
        //}

        [HttpGet(ApiRoutes.Account.ConfirmEmail)]
        public async Task<IActionResult> ConfirmEmail([FromQuery] AccountConfirmEmailQuery query)
        {
            try
            {
                var response = await _accountService.ConfirmEmailAsync(query.UserId, query.Token);
                if(response.Success)
                    return Ok();
                else
                    return BadRequest(new ErrorResponse(AccountErrorsToResponse.Parse(response)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse(ErrorMessages.Account.FailedConfirmEmail));
            }
        }

        //[HttpPost(ApiRoutes.Account.ForgotPassword)]
        //public async Task<IActionResult> ForgotPassword([FromBody] AccountForgotPasswordRequest postRequest)
        //{
        //    try
        //    {
        //        //var post = _mapper.Map<ArtistModel>(postRequest);
        //        //bool exists = await _artistService.ArtistNameExistsAsync(post);
        //        //if (exists)
        //        //    return BadRequest(new ErrorResponse(ErrorMessages.Artist.NameExists));

        //        //var artist = await _artistService.CreateArtistAsync(post);
        //        //var locationUri = ApiRoutes.Artists.Route + "/" + artist.ArtistId;
        //        //return Created(locationUri, new Response<ArtistResponse>(_mapper.Map<ArtistResponse>(artist)));
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, ErrorMessages.Account.FailedPasswordReset);
        //        return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse(ErrorMessages.Account.FailedPasswordReset));
        //    }
        //}

        //[HttpPost(ApiRoutes.Account.ResetPassword)]
        //public async Task<IActionResult> ResetPassword([FromBody] AccountResetPasswordRequest postRequest)
        //{
        //    try
        //    {
        //        //var post = _mapper.Map<ArtistModel>(postRequest);
        //        //bool exists = await _artistService.ArtistNameExistsAsync(post);
        //        //if (exists)
        //        //    return BadRequest(new ErrorResponse(ErrorMessages.Artist.NameExists));

        //        //var artist = await _artistService.CreateArtistAsync(post);
        //        //var locationUri = ApiRoutes.Artists.Route + "/" + artist.ArtistId;
        //        //return Created(locationUri, new Response<ArtistResponse>(_mapper.Map<ArtistResponse>(artist)));
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, ErrorMessages.Account.FailedPasswordReset);
        //        return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse(ErrorMessages.Account.FailedPasswordReset));
        //    }
        //}
    }
}

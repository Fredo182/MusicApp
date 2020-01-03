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

namespace MusicApp.API.Controllers.V1
{
    public class AccountsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public AccountsController(IMapper mapper, ILogger logger)
        {
            _mapper = mapper;
            _logger = logger;
        }

        //[HttpPost(ApiRoutes.Account.Register)]
        //public async Task<IActionResult> Register([FromBody] AccountRegisterRequest postRequest)
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
        //        _logger.LogError(ex, ErrorMessages.Account.FailedRegister);
        //        return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse(ErrorMessages.Account.FailedRegister));
        //    }
        //}

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

        //[HttpGet(ApiRoutes.Account.ConfirmEmail)]
        //public async Task<IActionResult> ConfirmEmail([FromQuery] AccountConfirmEmailQuery query)
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
        //        _logger.LogError(ex, ErrorMessages.Account.FailedConfirmEmail);
        //        return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse(ErrorMessages.Account.FailedConfirmEmail));
        //    }
        //}

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

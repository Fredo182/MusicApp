using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicApp.API.Contracts.V1;
using MusicApp.API.Contracts.V1.Requests.ArtistsRequests;
using MusicApp.API.Contracts.V1.Requests.Queries;
using MusicApp.API.Contracts.V1.Requests.Queries.Shared;
using MusicApp.API.Contracts.V1.Responses.ArtistsResponses;
using MusicApp.API.Contracts.V1.Responses.Shared;
using MusicApp.Services.Models;
using MusicApp.Services.Services.Interfaces;
using MusicApp.Services.Models.Queries.Shared;
using MusicApp.Services.Models.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace MusicApp.API.Controllers.V1
{
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistService _artistService;
        private readonly IMapper _mapper;

        public ArtistsController(IArtistService artistService, IMapper mapper)
        {
            _artistService = artistService;
            _mapper = mapper;
        }

        [HttpPost(ApiRoutes.Artists.CreateArtist)]
        public async Task<IActionResult> CreateArtist([FromBody] ArtistCreateRequest postRequest)
        {
            try
            {
                var post = _mapper.Map<ArtistModel>(postRequest);
                bool exists = await _artistService.ArtistNameExistsAsync(post);
                if (exists)
                    return BadRequest(new ErrorResponse(ErrorMessages.Artist.NameExists));

                var artist = await _artistService.CreateArtistAsync(post);
                var locationUri = ApiRoutes.Artists.Route + "/" + artist.ArtistId;
                return Created(locationUri, new Response<ArtistResponse>(_mapper.Map<ArtistResponse>(artist)));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse(ErrorMessages.Artist.FailedCreate));
            }
        }

        [HttpGet(ApiRoutes.Artists.GetArtist)]
        public async Task<IActionResult> GetArtist([FromRoute] int artistId)
        {
            try
            {
                var artist = await _artistService.GetArtistByIdAsync(artistId);
                if (artist == null)
                    return NotFound(new ErrorResponse(ErrorMessages.Artist.DoesNotExist));

                return Ok(new Response<ArtistResponse>(_mapper.Map<ArtistResponse>(artist)));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse(ErrorMessages.Artist.FailedRead));
            }
        }

        [HttpGet(ApiRoutes.Artists.GetArtists)]
        public async Task<IActionResult> GetArtists([FromQuery] ArtistFilterQuery filterQuery, [FromQuery] OrderByQuery orderByQuery, [FromQuery]PaginationQuery paginationQuery)
        {
            try
            {
                var pagination = _mapper.Map<PaginationModel>(paginationQuery);
                var orderBy = _mapper.Map<IEnumerable<ArtistOrderByModel>>(orderByQuery);
                var filter = _mapper.Map<ArtistFilterModel>(filterQuery);

                if (pagination.Valid)
                {
                    var artistsPaginationResult = await _artistService.GetPagedArtistsAsync(pagination, filter, orderBy);
                    var artistsResponse = _mapper.Map<List<ArtistResponse>>(artistsPaginationResult.Result);
                    return Ok(new PagedResponse<ArtistResponse>(artistsResponse, artistsPaginationResult.PageState));
                }
                else
                {
                    var artists = await _artistService.GetArtistsAsync(filter, orderBy);
                    return Ok(new Response<IEnumerable<ArtistResponse>>(_mapper.Map<IEnumerable<ArtistResponse>>(artists)));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse(ErrorMessages.Artist.FailedRead));
            }
        }

        [HttpPut(ApiRoutes.Artists.UpdateArtist)]
        public async Task<IActionResult> UpdateArtist([FromRoute] int artistId, [FromBody] ArtistUpdateRequest putRequest)
        {
            try
            {
                if (artistId != putRequest.ArtistId)
                    return BadRequest(new ErrorResponse(ErrorMessages.Artist.MismatchId));

                var exists = await _artistService.ArtistIdExistsAsync(artistId);
                if (!exists)
                    return NotFound(new ErrorResponse(ErrorMessages.Artist.DoesNotExist));

                var artistModel = _mapper.Map<ArtistModel>(putRequest);
                exists = await _artistService.ArtistNameExistsAsync(artistModel.Name);
                if (exists)
                    return BadRequest(new ErrorResponse(ErrorMessages.Artist.NameExists));

                var updated = await _artistService.UpdateArtistAsync(artistModel);

                if (updated != null)
                    return Ok(new Response<ArtistResponse>(_mapper.Map<ArtistResponse>(updated)));

                return NotFound();
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(DbUpdateConcurrencyException))
                    return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse(ErrorMessages.Artist.ConcurrencyIssue));

                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse(ErrorMessages.Artist.FailedUpdate));
            }
        }

        [HttpDelete(ApiRoutes.Artists.DeleteArtist)]
        public async Task<IActionResult> DeleteArtist([FromRoute] int artistId)
        {
            try
            {
                var exists = await _artistService.ArtistIdExistsAsync(artistId);
                if (!exists)
                    return NotFound(new ErrorResponse(ErrorMessages.Artist.DoesNotExist));

                var deleted = await _artistService.DeleteArtistAsync(artistId);
                if (deleted)
                    return NoContent();

                return NotFound(new ErrorResponse(ErrorMessages.Artist.DoesNotExist));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse(ErrorMessages.Artist.FailedDelete));
            }            
        }

        [HttpPost(ApiRoutes.Artists.CreateArtists)]
        public async Task<IActionResult> CreateArtists([FromBody] IEnumerable<ArtistCreateRequest> postRequest)
        {
            try
            {
                var posts = _mapper.Map<IEnumerable<ArtistModel>>(postRequest);
                var exist = await _artistService.ArtistNamesExistsAsync(posts);
                if (exist.Count() > 0)
                {
                    var existingNames = exist.Select(x => x.Name).ToList();
                    return BadRequest(new ErrorResponse(ErrorMessages.Artist.NameExistsBulk, existingNames));
                }
                var artists = await _artistService.CreateArtistsAsync(posts);
                var locationUri = ApiRoutes.Artists.Route;
                return Created(locationUri, new Response<IEnumerable<ArtistResponse>>(_mapper.Map<IEnumerable<ArtistResponse>>(artists)));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse(ErrorMessages.Artist.FailedCreateBulk));
            }
        }

        [HttpPut(ApiRoutes.Artists.UpdateArtists)]
        public async Task<IActionResult> UpdateArtists([FromBody] IEnumerable<ArtistUpdateRequest> putRequest)
        {
            try
            {
                var puts = _mapper.Map<IEnumerable<ArtistModel>>(putRequest);
                var notExist = await _artistService.ArtistsNotExistAsync(puts);
                if (notExist.Count() > 0)
                {
                    var notExistingNames = notExist.Select(x => x.Name).ToList();
                    return NotFound(new ErrorResponse(ErrorMessages.Artist.DoesNotExistBulk, notExistingNames));
                }

                var exist = await _artistService.ArtistNamesExistsAsync(puts);
                if (exist.Count() > 0)
                {
                    var existingNames = exist.Select(x => x.Name).ToList();
                    return BadRequest(new ErrorResponse(ErrorMessages.Artist.NameExistsBulk, existingNames));
                }

                var artists = await _artistService.UpdateArtistsAsync(puts);
                return Ok(new Response<IEnumerable<ArtistResponse>>(_mapper.Map<IEnumerable<ArtistResponse>>(artists)));
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(DbUpdateConcurrencyException))
                    return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse(ErrorMessages.Artist.ConcurrencyIssueBulk));

                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessages.Artist.FailedUpdateBulk);
            }
        }

        [HttpDelete(ApiRoutes.Artists.DeleteArtists)]
        public async Task<IActionResult> DeleteArtists([FromBody] int[] ids)
        {
            try
            {
                var allExist = await _artistService.ArtistIdsExistAsync(ids);
                if (!allExist)
                    return NotFound(new ErrorResponse(ErrorMessages.Artist.DoesNotExistBulk));

                var deleted = await _artistService.DeleteArtistsAsync(ids);
                if (deleted)
                    return NoContent();

                return NotFound(new ErrorResponse(ErrorMessages.Artist.DoesNotExistBulk));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse(ErrorMessages.Artist.FailedDeleteBulk));
            }
        }


        //Incldues

        [HttpGet(ApiRoutes.Artists.GetArtistAlbums)]
        public async Task<IActionResult> GetArtistAlbums([FromRoute] int artistId)
        {
            try
            {
                var artist = await _artistService.GetArtistAlbumsAsync(artistId);
                if (artist == null)
                    return NotFound(new ErrorResponse(ErrorMessages.Artist.DoesNotExist));

                return Ok(new Response<ArtistAlbumsResponse>(_mapper.Map<ArtistAlbumsResponse>(artist)));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse(ErrorMessages.Artist.FailedRead));
            }
        }

        [HttpGet(ApiRoutes.Artists.GetArtistAlbumsSongs)]
        public async Task<IActionResult> GetArtistAlbumsSongs([FromRoute] int artistId)
        {
            try
            {
                var artist = await _artistService.GetArtistAlbumsSongsAsync(artistId);
                if (artist == null)
                    return NotFound(new ErrorResponse(ErrorMessages.Artist.DoesNotExist));

                return Ok(new Response<ArtistAlbumsSongsResponse>(_mapper.Map<ArtistAlbumsSongsResponse>(artist)));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse(ErrorMessages.Artist.FailedRead));
            }
        }

        [HttpGet(ApiRoutes.Artists.GetArtistsAlbums)]
        public async Task<IActionResult> GetArtistsAlbums([FromQuery] ArtistFilterQuery filterQuery, [FromQuery] OrderByQuery orderByQuery, [FromQuery]PaginationQuery paginationQuery)
        {
            try
            {
                var pagination = _mapper.Map<PaginationModel>(paginationQuery);
                var orderBy = _mapper.Map<IEnumerable<ArtistOrderByModel>>(orderByQuery);
                var filter = _mapper.Map<ArtistFilterModel>(filterQuery);

                if (pagination.Valid)
                {
                    var artistsPaginationResult = await _artistService.GetPagedArtistsAlbumsAsync(pagination, filter, orderBy);
                    var artistsResponse = _mapper.Map<List<ArtistAlbumsResponse>>(artistsPaginationResult.Result);
                    return Ok(new PagedResponse<ArtistAlbumsResponse>(artistsResponse, artistsPaginationResult.PageState));
                }
                else
                {
                    var artists = await _artistService.GetArtistsAlbumsAsync(filter, orderBy);
                    return Ok(new Response<IEnumerable<ArtistAlbumsResponse>>(_mapper.Map<IEnumerable<ArtistAlbumsResponse>>(artists)));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse(ErrorMessages.Artist.FailedRead));
            }
        }

        [HttpGet(ApiRoutes.Artists.GetArtistsAlbumsSongs)]
        public async Task<IActionResult> GetArtistsAlbumsSongs([FromQuery] ArtistFilterQuery filterQuery, [FromQuery] OrderByQuery orderByQuery, [FromQuery]PaginationQuery paginationQuery)
        {
            try
            {
                var pagination = _mapper.Map<PaginationModel>(paginationQuery);
                var orderBy = _mapper.Map<IEnumerable<ArtistOrderByModel>>(orderByQuery);
                var filter = _mapper.Map<ArtistFilterModel>(filterQuery);

                if (pagination.Valid)
                {
                    var artistsPaginationResult = await _artistService.GetPagedArtistsAlbumsSongsAsync(pagination, filter, orderBy);
                    var artistsResponse = _mapper.Map<List<ArtistAlbumsSongsResponse>>(artistsPaginationResult.Result);
                    return Ok(new PagedResponse<ArtistAlbumsSongsResponse>(artistsResponse, artistsPaginationResult.PageState));
                }
                else
                {
                    var artists = await _artistService.GetArtistsAlbumsSongsAsync(filter, orderBy);
                    return Ok(new Response<IEnumerable<ArtistAlbumsSongsResponse>>(_mapper.Map<IEnumerable<ArtistAlbumsSongsResponse>>(artists)));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse(ErrorMessages.Artist.FailedRead));
            }
        }
    }
}

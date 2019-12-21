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
            var post = _mapper.Map<ArtistModel>(postRequest);
            bool exists = await _artistService.ArtistNameExistsAsync(post);
            if (exists)
                return BadRequest(new ErrorResponse(new ErrorModel { FieldName = "Name", Message = "Artist name already exists. Please enter new name." }));

            var artist = await _artistService.CreateArtistAsync(post);
            var locationUri = ApiRoutes.Artists.Route + "/" + artist.ArtistId;
            return Created(locationUri, new Response<ArtistResponse>(_mapper.Map<ArtistResponse>(artist)));
        }

        [HttpGet(ApiRoutes.Artists.GetArtist)]
        public async Task<IActionResult> GetArtist([FromRoute] int artistId)
        {
            var artist = await _artistService.GetArtistByIdAsync(artistId);
            if (artist == null)
                return NotFound(new ErrorResponse(new ErrorModel { Message = "Artist does not exist." }));

            return Ok(new Response<ArtistResponse>(_mapper.Map<ArtistResponse>(artist)));
        }

        [HttpGet(ApiRoutes.Artists.GetArtists)]
        public async Task<IActionResult> GetArtists([FromQuery] ArtistFilterQuery filterQuery, [FromQuery] OrderByQuery orderByQuery, [FromQuery]PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationModel>(paginationQuery);
            var orderBy = _mapper.Map<IEnumerable<ArtistOrderByModel>>(orderByQuery);
            var filter = _mapper.Map<ArtistFilterModel>(filterQuery);

            if (pagination.Valid)
            {
                var artistsPagedResponse = await _artistService.GetPagedArtistsAsync(pagination, filter, orderBy);
                var artistsResponse = _mapper.Map<List<ArtistResponse>>(artistsPagedResponse.Result);
                return Ok(new PagedResponse<ArtistResponse>(artistsResponse, artistsPagedResponse.PageState));
            }
            else
            {
                var artists = await _artistService.GetArtistsAsync(filter, orderBy);
                return Ok(new Response<IEnumerable<ArtistResponse>>(_mapper.Map<IEnumerable<ArtistResponse>>(artists)));
            }
        }

        [HttpPut(ApiRoutes.Artists.UpdateArtist)]
        public async Task<IActionResult> UpdateArtist([FromRoute] int artistId, [FromBody] ArtistUpdateRequest putRequest)
        {
            if (artistId != putRequest.ArtistId)
                return BadRequest(new ErrorResponse(new ErrorModel { Message = "ArtistId mismatch." }));

            var exists = await _artistService.ArtistIdExistsAsync(artistId);
            if (!exists)
                return NotFound(new ErrorResponse(new ErrorModel { Message = "Artist does not exist." }));

            var artistModel = _mapper.Map<ArtistModel>(putRequest);
            exists = await _artistService.ArtistNameExistsAsync(artistModel.Name);
            if (exists)
                return BadRequest(new ErrorResponse(new ErrorModel { FieldName = "Name", Message = "Artist name already exists. Please enter new name." }));

            var updated = await _artistService.UpdateArtistAsync(artistModel);

            if (updated != null)
                return Ok(new Response<ArtistResponse>(_mapper.Map<ArtistResponse>(updated)));

            return NotFound();
        }

        [HttpDelete(ApiRoutes.Artists.DeleteArtist)]
        public async Task<IActionResult> DeleteArtist([FromRoute] int artistId)
        {
            var exists = await _artistService.ArtistIdExistsAsync(artistId);
            if (!exists)
                return NotFound(new ErrorResponse(new ErrorModel { Message = "Artist does not exist." }));

            var deleted = await _artistService.DeleteArtistAsync(artistId);
            if (deleted)
                return NoContent();

            return NotFound(new ErrorResponse(new ErrorModel { Message = "Artist does not exist." }));

        }

        [HttpPost(ApiRoutes.Artists.CreateArtists)]
        public async Task<IActionResult> CreateArtists([FromBody] IEnumerable<ArtistCreateRequest> postRequest)
        {
            var posts = _mapper.Map<IEnumerable<ArtistModel>>(postRequest);
            var exist = await _artistService.ArtistNamesExistsAsync(posts);
            if (exist.Count() > 0)
            {
                var existingNames = exist.Select(x => x.Name).ToList();
                return BadRequest(new ErrorResponse(new ErrorModel { FieldName = "Name", Message = "Artist name already exists. Please enter new names for the following. [" + string.Join(',', existingNames) + "]" }));
            }
            var artists = await _artistService.CreateArtistsAsync(posts);
            var locationUri = ApiRoutes.Artists.Route;
            return Created(locationUri, new Response<IEnumerable<ArtistResponse>>(_mapper.Map<IEnumerable<ArtistResponse>>(artists)));
        }

        [HttpPut(ApiRoutes.Artists.UpdateArtists)]
        public async Task<IActionResult> UpdateArtists([FromBody] IEnumerable<ArtistUpdateRequest> putRequest)
        {
            var puts = _mapper.Map<IEnumerable<ArtistModel>>(putRequest);
            var notExist = await _artistService.ArtistsNotExistAsync(puts);
            if (notExist.Count() > 0)
            {
                var notExistingNames = notExist.Select(x => x.Name).ToList();
                return NotFound(new ErrorResponse(new ErrorModel { Message = "The following artist do not exist. [" + string.Join(',', notExistingNames) + "]" }));
            }

            var exist = await _artistService.ArtistNamesExistsAsync(puts);
            if (exist.Count() > 0)
            {
                var existingNames = exist.Select(x => x.Name).ToList();
                return BadRequest(new ErrorResponse(new ErrorModel { FieldName = "Name", Message = "Artist name already exists. Please enter new names for the following. [" + string.Join(',', existingNames) + "]" }));
            }

            var artists = await _artistService.UpdateArtistsAsync(puts);
            return Ok(new Response<IEnumerable<ArtistResponse>>(_mapper.Map<IEnumerable<ArtistResponse>>(artists)));
        }

        [HttpDelete(ApiRoutes.Artists.DeleteArtists)]
        public async Task<IActionResult> DeleteArtists([FromBody] int[] ids)
        {
            var allExist = await _artistService.ArtistIdsExistAsync(ids);
            if (!allExist)
                return NotFound(new ErrorResponse(new ErrorModel { Message = "An Artist does not exist." }));

            var deleted = await _artistService.DeleteArtistsAsync(ids);
            if (deleted)
                return NoContent();

            return NotFound(new ErrorResponse(new ErrorModel { Message = "An Artist does not exist." }));

        }
    }
}

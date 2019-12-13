using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicApp.API.Contracts.V1;
using MusicApp.API.Contracts.V1.Requests.ArtistsRequests;
using MusicApp.API.Contracts.V1.Responses.ArtistsResponses;
using MusicApp.API.Contracts.V1.Responses.Shared;
using MusicApp.Services.Models;
using MusicApp.Services.Services.Interfaces;

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
        public async Task<IActionResult> CreateArtist([FromBody] CreateArtistRequest postRequest)
        {
            var post = _mapper.Map<ArtistModel>(postRequest);
            bool exists = await _artistService.ArtistNameExistsAsync(post.Name);
            if (exists)
                return BadRequest(new ErrorResponse(new ErrorModel { FieldName = "Name", Message = "Artist name already exists. Please enter new name." }));

            var artist = await _artistService.CreateArtistAsync(post);
            return Ok(new Response<ArtistResponse>(_mapper.Map<ArtistResponse>(artist)));
        }

        [HttpGet(ApiRoutes.Artists.GetArtist)]
        public async Task<IActionResult> GetArtist([FromRoute] int artistId)
        {
            var artist = await _artistService.GetArtistByIdAsync(artistId);
            if (artist == null)
                return NotFound();

            return Ok(new Response<ArtistResponse>(_mapper.Map<ArtistResponse>(artist)));
        }

        [HttpPut(ApiRoutes.Artists.UpdateArtist)]
        public async Task<IActionResult> UpdateArtist([FromRoute] int artistId, [FromBody] UpdateArtistRequest putRequest)
        {
            var exists = await _artistService.ArtistIdExistsAsync(artistId);
            if (!exists)
                return NotFound(new ErrorResponse(new ErrorModel { Message = "Artist does not exist." }));

            var artistModel = _mapper.Map<ArtistModel>(putRequest);
            exists = await _artistService.ArtistNameExistsAsync(artistModel.Name);
            if (exists)
                return BadRequest(new ErrorResponse(new ErrorModel { FieldName = "Name", Message = "Artist name already exists. Please enter new name." }));

            artistModel.ArtistId = artistId;

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

        //[HttpPost(ApiRoutes.Artists.CreateArtists)]
        //public async Task<IActionResult> CreateArtists()
        //{

        //}

        //[HttpGet(ApiRoutes.Artists.GetArtists)]
        //public async Task<IActionResult> GetArtists()
        //{
        //    var artists = await _artistService.GetAllArtistsAsync();
        //    return Ok(artists);
        //}

        //[HttpGet(ApiRoutes.Artists.UpdateArtists)]
        //public async Task<IActionResult> UpdateArtists()
        //{

        //}

        //[HttpGet(ApiRoutes.Artists.DeleteArtists)]
        //public async Task<IActionResult> DeleteArtist()
        //{

        //}
    }
}

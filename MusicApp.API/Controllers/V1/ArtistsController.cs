using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicApp.API.Contracts.V1;
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

        //[HttpPost(ApiRoutes.Artists.CreateArtist)]
        //public async Task<IActionResult> CreateArtist()
        //{

        //}

        //[HttpGet(ApiRoutes.Artists.GetArtist)]
        //public async Task<IActionResult> GetArtist()
        //{

        //}

        //[HttpGet(ApiRoutes.Artists.UpdateArtist)]
        //public async Task<IActionResult> UpdateArtist()
        //{

        //}

        //[HttpGet(ApiRoutes.Artists.DeleteArtist)]
        //public async Task<IActionResult> DeleteArtist()
        //{

        //}

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

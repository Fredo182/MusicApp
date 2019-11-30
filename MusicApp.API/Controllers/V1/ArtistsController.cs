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

        //[HttpGet(ApiRoutes.Artists.GetArtists)]
        //public async Task<IActionResult> GetAll()
        //{
        //    var artists = await _artistService.get
        //}
    }
}

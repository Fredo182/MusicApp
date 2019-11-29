using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicApp.Services.Services.Interfaces;

namespace MusicApp.API.Controllers.V1
{
    public class ArtistGenresController : ControllerBase
    {
        private readonly IArtistGenreService _artistGenreService;
        private readonly IMapper _mapper;

        public ArtistGenresController(IArtistGenreService artistGenreService, IMapper mapper)
        {
            _artistGenreService = artistGenreService;
            _mapper = mapper;
        }
    }
}

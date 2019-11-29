using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
    }
}

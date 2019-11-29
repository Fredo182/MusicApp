using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicApp.Services.Services.Interfaces;

namespace MusicApp.API.Controllers.V1
{
    public class SongsController : ControllerBase
    {
        private readonly ISongService _songService;
        private readonly IMapper _mapper;

        public SongsController(ISongService songService, IMapper mapper)
        {
            _songService = songService;
            _mapper = mapper;
        }
    }
}

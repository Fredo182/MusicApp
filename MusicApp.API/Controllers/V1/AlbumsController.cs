using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicApp.Services.Services.Interfaces;

namespace MusicApp.API.Controllers.V1
{
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumService _albumService;
        private readonly IMapper _mapper;

        public AlbumsController(IAlbumService albumService, IMapper mapper)
        {
            _albumService = albumService;
            _mapper = mapper;
        }
    }
}

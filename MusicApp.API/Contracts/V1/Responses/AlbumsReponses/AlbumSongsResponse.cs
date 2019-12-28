using System;
using System.Collections.Generic;
using MusicApp.API.Contracts.V1.Responses.SongsReponses;

namespace MusicApp.API.Contracts.V1.Responses.AlbumsReponses
{
    public class AlbumSongsResponse : AlbumResponse
    {
        public List<SongResponse> Songs { get; set; }
    }
}

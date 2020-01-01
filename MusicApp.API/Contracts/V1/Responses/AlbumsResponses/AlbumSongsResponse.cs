using System;
using System.Collections.Generic;
using MusicApp.API.Contracts.V1.Responses.SongsReponses;

namespace MusicApp.API.Contracts.V1.Responses.AlbumsResponses
{
    public class AlbumSongsResponse : AlbumResponse
    {
        public AlbumSongsResponse()
        {
            Songs = new List<SongResponse>();
        }

        public List<SongResponse> Songs { get; private set; }
    }
}

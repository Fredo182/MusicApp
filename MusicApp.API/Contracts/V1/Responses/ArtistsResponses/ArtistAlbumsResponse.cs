using System;
using System.Collections.Generic;
using MusicApp.API.Contracts.V1.Responses.AlbumsResponses;

namespace MusicApp.API.Contracts.V1.Responses.ArtistsResponses
{
    public class ArtistAlbumsResponse : ArtistResponse
    {
        public ArtistAlbumsResponse()
        {
            Albums = new List<AlbumResponse>();
        }

        public List<AlbumResponse> Albums { get; private set; }
    }
}

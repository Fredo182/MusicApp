using System;
using System.Collections.Generic;
using MusicApp.API.Contracts.V1.Responses.AlbumsResponses;

namespace MusicApp.API.Contracts.V1.Responses.ArtistsResponses
{
    public class ArtistAlbumsSongsResponse : ArtistResponse
    {
        public ArtistAlbumsSongsResponse()
        {
            Albums = new List<AlbumSongsResponse>();
        }

        public List<AlbumSongsResponse> Albums { get; set; }
    }
}

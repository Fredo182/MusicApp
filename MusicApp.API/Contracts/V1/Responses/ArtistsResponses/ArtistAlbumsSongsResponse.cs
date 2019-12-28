using System;
using System.Collections.Generic;
using MusicApp.API.Contracts.V1.Responses.AlbumsReponses;

namespace MusicApp.API.Contracts.V1.Responses.ArtistsResponses
{
    public class ArtistAlbumsSongsResponse : ArtistResponse
    {
        public List<AlbumSongsResponse> Albums { get; set; }
    }
}

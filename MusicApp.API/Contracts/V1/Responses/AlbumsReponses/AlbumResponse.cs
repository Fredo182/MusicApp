using System;
using MusicApp.API.Contracts.V1.Responses.Shared;

namespace MusicApp.API.Contracts.V1.Responses.AlbumsReponses
{
    public class AlbumResponse : BaseResponse
    {
        public int AlbumId { get; set; }

        public string Name { get; set; }

        public int ArtistId { get; set; }

    }
}

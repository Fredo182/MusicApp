using System;
using MusicApp.API.Contracts.V1.Responses.Shared;

namespace MusicApp.API.Contracts.V1.Responses.SongsReponses
{
    public class SongResponse : BaseResponse
    {
        public int SongId { get; set; }

        public string Name { get; set; }

        public int AlbumId { get; set; }

    }
}

using System;
using MusicApp.API.Contracts.V1.Responses.Shared;

namespace MusicApp.API.Contracts.V1.Responses.ArtistsResponses
{
    public class ArtistResponse : BaseResponse
    {
        public int ArtistId { get; set; }

        public string Name { get; set; }

    }
}

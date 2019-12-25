using System;
using MusicApp.API.Contracts.V1.Requests.Shared;

namespace MusicApp.API.Contracts.V1.Requests.ArtistsRequests
{
    public class ArtistUpdateRequest : BaseRequest
    {
        public int ArtistId { get; set; }

        public string Name { get; set; }
    }
}

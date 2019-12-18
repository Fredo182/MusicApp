using System;
namespace MusicApp.API.Contracts.V1.Requests.ArtistsRequests
{
    public class ArtistUpdateRequest
    {
        public int ArtistId { get; set; }

        public string Name { get; set; }
    }
}

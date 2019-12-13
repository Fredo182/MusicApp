using System;
namespace MusicApp.API.Contracts.V1.Requests.ArtistsRequests
{
    public class UpdateArtistRequest
    {
        public int ArtistId { get; set; }

        public string Name { get; set; }
    }
}

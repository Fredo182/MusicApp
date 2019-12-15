using System;
namespace MusicApp.API.Contracts.V1.Requests.Queries.ArtistsQueries
{
    public class GetArtistsQuery
    {
        public int ArtistId { get; set; }

        public string Name { get; set; }
    }
}

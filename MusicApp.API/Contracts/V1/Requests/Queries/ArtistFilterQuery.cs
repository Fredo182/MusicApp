using System;
namespace MusicApp.API.Contracts.V1.Requests.Queries
{
    public class ArtistFilterQuery
    {
        public int? ArtistId { get; set; }

        public string Name { get; set; }
    }
}

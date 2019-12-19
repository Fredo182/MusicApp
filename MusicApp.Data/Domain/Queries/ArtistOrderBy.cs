using System;
namespace MusicApp.Data.Domain.Queries
{
    public class ArtistOrderBy
    {
        public bool? ArtistId { get; set; }

        public bool? Name { get; set; }

        public string OrderType { get; set; }
    }
}

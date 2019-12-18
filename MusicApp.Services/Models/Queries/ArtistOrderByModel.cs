using System;
namespace MusicApp.Services.Models.Queries
{
    public class ArtistOrderByModel
    {
        public bool? ArtistId { get; set; }

        public bool? Name { get; set; }

        public string SortType { get; set; }

    }
}

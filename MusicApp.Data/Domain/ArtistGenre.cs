using System;
using MusicApp.Data.Domain.Shared;

namespace MusicApp.Data.Domain
{
    public class ArtistGenre : BaseDomain
    {
        public int ArtistGenreId { get; set; }

        public int ArtistId { get; set; }

        public Artist Artist { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }
    }
}

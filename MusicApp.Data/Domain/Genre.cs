using System;
using System.Collections.Generic;

namespace MusicApp.Data.Domain
{
    public class Genre
    {
        public int GenreId { get; set; }

        public string Name { get; set; }

        public List<ArtistGenre> ArtistGenres { get; set; }
    }
}

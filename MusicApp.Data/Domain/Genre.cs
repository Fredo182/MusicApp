using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MusicApp.Data.Domain
{
    public class Genre
    {
        public int GenreId { get; set; }

        public string Name { get; set; }

        public ICollection<ArtistGenre> ArtistGenres { get; set; }
    }
}

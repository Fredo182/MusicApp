using System;
using System.Collections.Generic;
using MusicApp.Data.Domain.Shared;

namespace MusicApp.Data.Domain
{
    public class Genre : BaseDomain
    {
        public Genre()
        {
            ArtistGenres = new List<ArtistGenre>();
        }

        public int GenreId { get; set; }

        public string Name { get; set; }

        public ICollection<ArtistGenre> ArtistGenres { get; private set; }
    }
}

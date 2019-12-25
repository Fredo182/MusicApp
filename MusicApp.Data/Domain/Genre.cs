using System;
using System.Collections.Generic;
using MusicApp.Data.Domain.Shared;

namespace MusicApp.Data.Domain
{
    public class Genre : BaseDomain
    {
        public int GenreId { get; set; }

        public string Name { get; set; }

        public ICollection<ArtistGenre> ArtistGenres { get; set; }
    }
}

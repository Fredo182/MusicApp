using System;
using System.Collections.Generic;
using MusicApp.Data.Domain.Shared;

namespace MusicApp.Data.Domain
{
    public class Artist : BaseDomain
    {
        public int ArtistId { get; set; }

        public string Name { get; set; }

        public ICollection<Album> Albums { get; set; }

        public ICollection<ArtistGenre> ArtistGenres { get; set; }

    }
}

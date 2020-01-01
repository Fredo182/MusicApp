using System;
using System.Collections.Generic;
using MusicApp.Data.Domain.Shared;

namespace MusicApp.Data.Domain
{
    public class Artist : BaseDomain
    {
        public Artist()
        {
            Albums = new List<Album>();
            ArtistGenres = new List<ArtistGenre>();
        }

        public int ArtistId { get; set; }

        public string Name { get; set; }

        public ICollection<Album> Albums { get; private set; }

        public ICollection<ArtistGenre> ArtistGenres { get; private set; }

    }
}

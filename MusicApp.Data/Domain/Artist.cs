using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MusicApp.Data.Domain
{
    public class Artist
    {
        public int ArtistId { get; set; }

        public string Name { get; set; }

        public ICollection<Album> Albums { get; set; }

        public ICollection<ArtistGenre> ArtistGenres { get; set; } 
    }
}

using System;
using System.Collections.Generic;

namespace MusicApp.Data.Domain
{
    public class Artist
    {
        public int ArtistId { get; set; }

        public string Name { get; set; }

        public List<Album> Albums { get; set; }

        public List<ArtistGenre> ArtistGenres { get; set; } 
    }
}

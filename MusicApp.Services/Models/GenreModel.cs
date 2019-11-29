using System;
using System.Collections.Generic;

namespace MusicApp.Services.Models
{
    public class GenreModel
    {
        public int GenreId { get; set; }

        public string Name { get; set; }

        public List<ArtistGenreModel> ArtistGenres { get; set; }
    }
}

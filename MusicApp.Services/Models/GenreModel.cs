using System;
using System.Collections.Generic;
using MusicApp.Services.Models.Shared;

namespace MusicApp.Services.Models
{
    public class GenreModel : BaseModel
    {
        public GenreModel()
        {
            ArtistGenres = new List<ArtistGenreModel>();
        }

        public int GenreId { get; set; }

        public string Name { get; set; }

        public List<ArtistGenreModel> ArtistGenres { get; private set; }
    }
}

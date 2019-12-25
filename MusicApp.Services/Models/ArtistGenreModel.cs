using System;
using MusicApp.Services.Models.Shared;

namespace MusicApp.Services.Models
{
    public class ArtistGenreModel : BaseModel
    {
        public int ArtistGenreId { get; set; }

        public int ArtistId { get; set; }

        public ArtistModel Artist { get; set; }

        public int GenreId { get; set; }

        public GenreModel Genre { get; set; }
    }
}

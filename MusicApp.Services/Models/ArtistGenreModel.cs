using System;
namespace MusicApp.Services.Models
{
    public class ArtistGenreModel
    {
        public int ArtistId { get; set; }

        public ArtistModel Artist { get; set; }

        public int GenreId { get; set; }

        public GenreModel Genre { get; set; }
    }
}

using System;
using System.Collections.Generic;
using MusicApp.Services.Models.Shared;

namespace MusicApp.Services.Models
{
    public class ArtistModel : BaseModel
    {
        public ArtistModel()
        {
            Albums = new List<AlbumModel>();
            ArtistGenres = new List<ArtistGenreModel>();
        }

        public int ArtistId { get; set; }

        public string Name { get; set; }

        public List<AlbumModel> Albums { get; private set; }

        public List<ArtistGenreModel> ArtistGenres { get; private set; }
    }
}

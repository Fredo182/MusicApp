using System;
using System.Collections.Generic;
using MusicApp.Services.Models.Shared;

namespace MusicApp.Services.Models
{
    public class ArtistModel : BaseModel
    {
        public int ArtistId { get; set; }

        public string Name { get; set; }

        public List<AlbumModel> Albums { get; set; }

        public List<ArtistGenreModel> ArtistGenres { get; set; }
    }
}

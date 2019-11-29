using System;
using System.Collections.Generic;

namespace MusicApp.Services.Models
{
    public class AlbumModel
    {
        public int AlbumId { get; set; }

        public string Name { get; set; }

        public int ArtistId { get; set; }

        public ArtistModel Artist { get; set; }

        public List<SongModel> Songs { get; set; }
    }
}

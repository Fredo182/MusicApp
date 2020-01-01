using System;
using System.Collections.Generic;
using MusicApp.Services.Models.Shared;

namespace MusicApp.Services.Models
{
    public class AlbumModel : BaseModel
    {
        public AlbumModel()
        {
            Songs = new List<SongModel>();
        }

        public int AlbumId { get; set; }

        public string Name { get; set; }

        public int ArtistId { get; set; }

        public ArtistModel Artist { get; set; }

        public List<SongModel> Songs { get; private set; }
    }
}

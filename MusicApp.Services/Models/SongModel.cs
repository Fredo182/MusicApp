using System;
using MusicApp.Services.Models.Shared;

namespace MusicApp.Services.Models
{
    public class SongModel : BaseModel
    {
        public int SongId { get; set; }

        public string Name { get; set; }

        public int AlbumId { get; set; }

        public AlbumModel Album { get; set; }
    }
}

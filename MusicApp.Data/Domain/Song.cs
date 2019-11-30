using System;

namespace MusicApp.Data.Domain
{
    public class Song
    {
        public int SongId { get; set; }

        public string Name { get; set; }

        public int AlbumId { get; set; }

        public Album Album { get; set; }
    }
}

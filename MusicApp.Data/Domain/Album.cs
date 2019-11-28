using System;
using System.Collections.Generic;

namespace MusicApp.Data.Domain
{
    public class Album
    {
        public int AlbumId { get; set; }

        public string Name { get; set; }

        public int ArtistId { get; set; }

        public Artist Artist { get; set; }

        public List<Song> Songs { get; set; }

    }
}

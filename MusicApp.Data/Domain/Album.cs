using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MusicApp.Data.Domain
{
    public class Album
    {
        public int AlbumId { get; set; }

        public string Name { get; set; }

        public int ArtistId { get; set; }

        public Artist Artist { get; set; }

        public ICollection<Song> Songs { get; set; }

    }
}

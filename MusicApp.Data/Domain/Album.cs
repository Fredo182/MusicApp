using System;
using System.Collections.Generic;
using MusicApp.Data.Domain.Shared;

namespace MusicApp.Data.Domain
{
    public class Album : BaseDomain
    {
        public Album()
        {
            Songs = new List<Song>();
        }

        public int AlbumId { get; set; }

        public string Name { get; set; }

        public int ArtistId { get; set; }

        public Artist Artist { get; set; }

        public ICollection<Song> Songs { get; private set; }

    }
}

using System;
using System.Collections.Generic;

namespace MusicApp.Data.Domain
{
    public class Album
    {

        public Album()
        {
            Songs = new List<Song>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public int ArtistId { get; set; }

        public Artist Artist { get; set; }

        public IEnumerable<Song> Songs { get; set; }
    }
}

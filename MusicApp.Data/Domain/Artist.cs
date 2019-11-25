using System;
using System.Collections.Generic;

namespace MusicApp.Data.Domain
{
    public class Artist
    {
        public Artist()
        {
            Albums = new List<Album>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Album> Albums { get; set; }
    }
}

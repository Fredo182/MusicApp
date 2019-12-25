using System;
using MusicApp.Data.Domain.Shared;

namespace MusicApp.Data.Domain
{
    public class Song : BaseDomain
    {
        public int SongId { get; set; }

        public string Name { get; set; }

        public int AlbumId { get; set; }

        public Album Album { get; set; }
    }
}

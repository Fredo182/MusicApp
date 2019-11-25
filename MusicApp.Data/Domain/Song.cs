﻿using System;
namespace MusicApp.Data.Domain
{
    public class Song
    {
        public int Id { get; set; }

        public int Name { get; set; }

        public int AlbumId { get; set; }

        public Album Album { get; set; }
    }
}

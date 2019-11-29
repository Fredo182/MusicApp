﻿using System;
namespace MusicApp.Core.Models
{
    public class SongModel
    {
        public int SongId { get; set; }

        public int Name { get; set; }

        public int AlbumId { get; set; }

        public AlbumModel Album { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;

namespace MusicApp.Data.Domain
{
    public class Artist
    {
        public int ArtistId { get; set; }

        public string Name { get; set; }

        public virtual List<Album> Albums { get; set; }
    }
}
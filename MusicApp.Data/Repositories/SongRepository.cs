﻿using System;
using MusicApp.Data.Domain;
using MusicApp.Data.Repositories.Interfaces;
using MusicApp.Data.Repositories.Shared;

namespace MusicApp.Data.Repositories
{
    public class SongRepository : CrudRepository<Song>, ISongRepository
    {
        public SongRepository(MusicAppDbContext context) : base(context){ }

        private MusicAppDbContext MusicAppDbContext
        {
            get { return context as MusicAppDbContext; }
        }

        // Add other methods besides the basic CRUD below
        // e.g.
        // ....
        // ....
    }
}

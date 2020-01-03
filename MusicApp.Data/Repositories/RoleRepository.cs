﻿using System;
using Microsoft.AspNetCore.Identity;
using MusicApp.Data.Domain.Authorization;
using MusicApp.Data.Repositories.Interfaces;
using MusicApp.Data.Repositories.Shared;

namespace MusicApp.Data.Repositories.Authorization
{
    public class RoleRepository : CrudRepository<Role>, IRoleRepository
    {
        public RoleRepository(MusicAppDbContext context) : base(context) { }

        private MusicAppDbContext MusicAppDbContext
        {
            get { return context as MusicAppDbContext; }
        }

        // Add other methods besides the basic CRUD below
        // e.g.
        // ....
        // ....

        //public async Task<IEnumerable<Artist>> GetAllWithAlbumsAsync()
        //{
        //    return await MusicAppDbContext.Artists.Include(a => a.Albums).ToListAsync();
        //}

        //public async Task<Artist> GetWithAlbumsByIdAsync(int id)
        //{
        //    return await MusicAppDbContext.Artists.Include(a => a.Albums).SingleOrDefaultAsync(a => a.ArtistId == id);
        //}
    }
}
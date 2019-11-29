using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicApp.Data.Domain;
using MusicApp.Data.Repositories.Interfaces;
using MusicApp.Data.Repositories.Shared;

namespace MusicApp.Data.Repositories
{
    public class ArtistRepository : CrudRepository<Artist>, IArtistRepository
    {
        public ArtistRepository(MusicAppDbContext context) : base(context){ }

        private MusicAppDbContext MusicAppDbContext
        {
            get { return context as MusicAppDbContext; }
        }

        // Add other methods besides the basic CRUD below
        // e.g.
        // ....
        // ....

        public async Task<IEnumerable<Artist>> GetAllWithAlbumsAsync()
        {
            return await MusicAppDbContext.Artists.Include(a => a.Albums).ToListAsync();
        }

        public async Task<Artist> GetWithAlbumsByIdAsync(int id)
        {
            return await MusicAppDbContext.Artists.Include(a => a.Albums).SingleOrDefaultAsync(a => a.ArtistId == id);
        }
    }
}

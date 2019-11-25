using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MusicApp.Core.Domain;
using MusicApp.Core.Repositories.Shared;

namespace MusicApp.Core.Repositories
{
    public interface IArtistRepository : ICrudRepository<Artist>
    {
        // add additional methods here
        //..
        //..

        // e.g

        //Task<IEnumerable<Artist>> GetAllWithAlbumsAsync();

        //Task<Artist> GetWithAlbumsByIdAsync(int id);

        //Task<IEnumerable<Artist>> GetAllWithAlbumsAndSongsAsync();

        //Task<Artist> GetWithAlbumsAndSOngsByIdAsync(int id);
    }
}

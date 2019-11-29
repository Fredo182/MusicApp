using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MusicApp.Data.Domain;
using MusicApp.Data.Repositories.Interfaces.Shared;

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

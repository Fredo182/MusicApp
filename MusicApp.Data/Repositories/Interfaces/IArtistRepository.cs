using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MusicApp.Data.Domain;
using MusicApp.Data.Repositories.Interfaces.Shared;

namespace MusicApp.Data.Repositories.Interfaces
{
    public interface IArtistRepository : ICrudRepository<Artist>
    {
        // Add additional methods besides basic crud below
        // e.g.
        // ....
        // ....
        // ....

        Task<IEnumerable<Artist>> GetAllWithAlbumsAsync();

        Task<Artist> GetWithAlbumsByIdAsync(int id);

    }
}

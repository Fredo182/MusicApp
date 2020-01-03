using System;
using MusicApp.Data.Domain.Authorization;
using MusicApp.Data.Repositories.Interfaces.Shared;

namespace MusicApp.Data.Repositories.Interfaces
{
    public interface IUserRepository : ICrudRepository<User>
    {
        // Add additional methods besides basic crud below
        // e.g.
        // ....
        // ....
        // ....

        //Task<IEnumerable<Artist>> GetAllWithAlbumsAsync();

        //Task<Artist> GetWithAlbumsByIdAsync(int id);
    }
}

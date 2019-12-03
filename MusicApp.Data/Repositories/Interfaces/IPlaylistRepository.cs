using System;
using MusicApp.Data.Domain;
using MusicApp.Data.Repositories.Interfaces.Shared;

namespace MusicApp.Data.Repositories.Interfaces
{
    public interface IPlaylistRepository : ICrudRepository<Playlist>
    {
        // add additional methods here
        //..
        //..

        // e.g

        //Task<IEnumerable<Artist>> GetAllWithAlbumsAsync();

        //Task<Artist> GetWithAlbumsByIdAsync(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MusicApp.Services.Models;

namespace MusicApp.Services.Services.Interfaces
{
    public interface IPlaylistService
    {
        // CREATE
        Task<PlaylistModel> CreatePlaylistAsync(PlaylistModel playlist);
        Task<IEnumerable<PlaylistModel>> CreatePlaylistsAsync(IEnumerable<PlaylistModel> playlists);

        // READ
        Task<PlaylistModel> GetPlaylistByIdAsync(int id);
        Task<PlaylistModel> GetPlaylistAsync(PlaylistModel playlist);
        Task<IEnumerable<PlaylistModel>> GetAllPlaylistsAsync();

        // UPDATE
        Task<PlaylistModel> UpdatePlaylistAsync(PlaylistModel playlist);
        Task<IEnumerable<PlaylistModel>> UpdatePlaylistsAsync(IEnumerable<PlaylistModel> playlists);

        // DELETE
        Task DeletePlaylistAsync(PlaylistModel playlist);
        Task DeletePlaylisysAsync(IEnumerable<PlaylistModel> playlists);
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MusicApp.Services.Models;

namespace MusicApp.Services.Services.Interfaces
{
    public interface IAlbumService
    {
        // CREATE
        Task<AlbumModel> CreateAlbumAsync(AlbumModel album);
        Task<IEnumerable<AlbumModel>> CreateAlbumsAsync(IEnumerable<AlbumModel> albums);

        // READ
        Task<AlbumModel> GetAlbumByIdAsync(int id);
        Task<AlbumModel> GetAlbumAsync(AlbumModel album);
        Task<IEnumerable<AlbumModel>> GetAllAlbumsAsync();
        Task<bool> AlbumExistsAsync(int id);

        // UPDATE
        Task<AlbumModel> UpdateAlbumAsync(AlbumModel album);
        Task<IEnumerable<AlbumModel>> UpdateAlbumsAsync(IEnumerable<AlbumModel> albums);

        // DELETE
        Task<bool> DeleteAlbumAsync(AlbumModel album);
        Task<bool> DeleteAlbumAsync(params object[] id);
        Task DeleteAlbumsAsync(IEnumerable<AlbumModel> albums);

    }
}

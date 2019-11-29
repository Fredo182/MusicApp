using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MusicApp.Services.Models;

namespace MusicApp.Services.Services.Interfaces
{
    public interface IAlbumService
    {
        // CREATE
        Task<AlbumModel> CreateAlbum(AlbumModel album);
        Task<IEnumerable<AlbumModel>> CreateAlbums(IEnumerable<AlbumModel> albums);

        // READ
        Task<AlbumModel> GetAlbumById(int id);
        Task<AlbumModel> GetAlbum(AlbumModel album);
        Task<IEnumerable<AlbumModel>> GetAllAlbums();

        // UPDATE
        Task<AlbumModel> UpdateAlbum(AlbumModel album);
        Task<IEnumerable<AlbumModel>> UpdateAlbums(IEnumerable<AlbumModel> albums);

        // DELETE
        Task DeleteAlbum(AlbumModel album);
        Task DeleteAlbums(IEnumerable<AlbumModel> albums);

    }
}

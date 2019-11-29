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
        AlbumModel UpdateAlbum(AlbumModel album);
        IEnumerable<AlbumModel> UpdateAlbums(IEnumerable<AlbumModel> albums);

        // DELETE
        void DeleteAlbum(AlbumModel album);
        void DeleteAlbums(IEnumerable<AlbumModel> albums);

    }
}

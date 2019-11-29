using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MusicApp.Data.UnitOfWork.Interfaces;
using MusicApp.Services.Models;
using MusicApp.Services.Services.Interfaces;

namespace MusicApp.Services.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AlbumService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Task<AlbumModel> CreateAlbum(AlbumModel album)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AlbumModel>> CreateAlbums(IEnumerable<AlbumModel> albums)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAlbum(AlbumModel album)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAlbums(IEnumerable<AlbumModel> albums)
        {
            throw new NotImplementedException();
        }

        public Task<AlbumModel> GetAlbum(AlbumModel album)
        {
            throw new NotImplementedException();
        }

        public Task<AlbumModel> GetAlbumById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AlbumModel>> GetAllAlbums()
        {
            throw new NotImplementedException();
        }

        public Task<AlbumModel> UpdateAlbum(AlbumModel album)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AlbumModel>> UpdateAlbums(IEnumerable<AlbumModel> albums)
        {
            throw new NotImplementedException();
        }
    }
}

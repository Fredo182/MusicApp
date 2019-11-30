using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MusicApp.Data.Domain;
using MusicApp.Data.UnitOfWork.Interfaces;
using MusicApp.Services.Models;
using MusicApp.Services.Services.Interfaces;

namespace MusicApp.Services.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AlbumService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<AlbumModel> CreateAlbumAsync(AlbumModel album)
        {
            var a = _mapper.Map<AlbumModel, Album>(album);
            a = await _unitOfWork.Albums.AddAsync(a);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<Album, AlbumModel>(a);
        }

        public async Task<IEnumerable<AlbumModel>> CreateAlbumsAsync(IEnumerable<AlbumModel> albums)
        {
            var a = _mapper.Map<IEnumerable<AlbumModel>, IEnumerable<Album>>(albums);
            a = await _unitOfWork.Albums.AddRangeAsync(a);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<IEnumerable<Album>, IEnumerable<AlbumModel>>(a);
        }

        public async Task DeleteAlbumAsync(AlbumModel album)
        {
            var a = _mapper.Map<AlbumModel, Album>(album);
            _unitOfWork.Albums.Delete(a);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAlbumsAsync(IEnumerable<AlbumModel> albums)
        {
            var a = _mapper.Map<IEnumerable<AlbumModel>, IEnumerable<Album>>(albums);
            _unitOfWork.Albums.DeleteRange(a);
            await _unitOfWork.CommitAsync();
        }

        public async Task<AlbumModel> GetAlbumAsync(AlbumModel album)
        {
            //TODO: This one needs to be updated to use filtering
            var a = _mapper.Map<AlbumModel, Album>(album);
            a = await _unitOfWork.Albums.GetByIdAsync(a.AlbumId);
            return _mapper.Map<Album, AlbumModel>(a);
        }

        public async Task<AlbumModel> GetAlbumByIdAsync(int id)
        {
            var a = await _unitOfWork.Albums.GetByIdAsync(id);
            return _mapper.Map<Album, AlbumModel>(a);
        }

        public async Task<IEnumerable<AlbumModel>> GetAllAlbumsAsync()
        {
            var a = await _unitOfWork.Albums.GetAsync();
            return _mapper.Map<IEnumerable<Album>, IEnumerable<AlbumModel>>(a);
        }

        public async Task<AlbumModel> UpdateAlbumAsync(AlbumModel album)
        {
            var a = _mapper.Map<AlbumModel, Album>(album);
            a = _unitOfWork.Albums.Update(a);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<Album, AlbumModel>(a);
        }

        public async Task<IEnumerable<AlbumModel>> UpdateAlbumsAsync(IEnumerable<AlbumModel> albums)
        {
            var a = _mapper.Map<IEnumerable<AlbumModel>, IEnumerable<Album>>(albums);
            a = _unitOfWork.Albums.UpdateRange(a);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<IEnumerable<Album>, IEnumerable<AlbumModel>>(a);
        }
    }
}

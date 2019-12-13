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
    public class SongService : ISongService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SongService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<SongModel> CreateSongAsync(SongModel song)
        {
            var s = _mapper.Map<Song>(song);
            s = await _unitOfWork.Songs.AddAsync(s);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<SongModel>(s);
        }

        public async Task<IEnumerable<SongModel>> CreateSongsAsync(IEnumerable<SongModel> songs)
        {
            var s = _mapper.Map<IEnumerable<Song>>(songs);
            s = await _unitOfWork.Songs.AddRangeAsync(s);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<IEnumerable<SongModel>>(s);
        }

        public async Task<bool> DeleteSongAsync(SongModel song)
        {
            var s = _mapper.Map<Song>(song);
            _unitOfWork.Songs.Delete(s);
            var deleted = await _unitOfWork.CommitAsync();
            return deleted > 0;
        }

        public async Task<bool> DeleteSongAsync(params object[] id)
        {
            _unitOfWork.Songs.Delete(id);
            var deleted = await _unitOfWork.CommitAsync();
            return deleted > 0;
        }

        public async Task DeleteSongsAsync(IEnumerable<SongModel> songs)
        {
            var s = _mapper.Map<IEnumerable<Song>>(songs);
            _unitOfWork.Songs.DeleteRange(s);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<SongModel>> GetAllSongsAsync()
        {
            var s = await _unitOfWork.Songs.GetAsync();
            return _mapper.Map<IEnumerable<SongModel>>(s);
        }

        public async Task<SongModel> GetSongAsync(SongModel song)
        {
            var s = _mapper.Map<Song>(song);
            s = await _unitOfWork.Songs.GetByIdAsync(s.SongId);
            return _mapper.Map<SongModel>(s);
        }

        public async Task<SongModel> GetSongByIdAsync(int id)
        {
            var s = await _unitOfWork.Songs.GetByIdAsync(id);
            return _mapper.Map<SongModel>(s);
        }

        public async Task<bool> SongExistsAsync(int id)
        {
            var s = await _unitOfWork.Songs.ExistsAsync(s => s.SongId == id);
            return s;
        }

        public async Task<SongModel> UpdateSongAsync(SongModel song)
        {
            var s = _mapper.Map<Song>(song);
            s = _unitOfWork.Songs.Update(s);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<SongModel>(s);
        }

        public async Task<IEnumerable<SongModel>> UpdateSongsAsync(IEnumerable<SongModel> songs)
        {
            var s = _mapper.Map<IEnumerable<Song>>(songs);
            s = _unitOfWork.Songs.UpdateRange(s);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<IEnumerable<SongModel>>(s);
        }

    }
}

﻿using System;
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

        public SongService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<SongModel> CreateSong(SongModel song)
        {
            var s = _mapper.Map<SongModel, Song>(song);
            s = await _unitOfWork.Songs.AddAsync(s);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<Song, SongModel>(s);
        }

        public async Task<IEnumerable<SongModel>> CreateSongs(IEnumerable<SongModel> songs)
        {
            var s = _mapper.Map<IEnumerable<SongModel>, IEnumerable<Song>>(songs);
            s = await _unitOfWork.Songs.AddRangeAsync(s);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<IEnumerable<Song>, IEnumerable<SongModel>>(s);
        }

        public async Task DeleteSong(SongModel song)
        {
            var s = _mapper.Map<SongModel, Song>(song);
            _unitOfWork.Songs.Delete(s);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteSongs(IEnumerable<SongModel> songs)
        {
            var s = _mapper.Map<IEnumerable<SongModel>, IEnumerable<Song>>(songs);
            _unitOfWork.Songs.DeleteRange(s);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<SongModel>> GetAllSongs()
        {
            var s = await _unitOfWork.Songs.GetAsync();
            return _mapper.Map<IEnumerable<Song>, IEnumerable<SongModel>>(s);
        }

        public async Task<SongModel> GetSong(SongModel song)
        {
            //TODO: This one needs to be updated to use filtering
            var s = _mapper.Map<SongModel, Song>(song);
            s = await _unitOfWork.Songs.GetByIdAsync(s.SongId);
            return _mapper.Map<Song, SongModel>(s);
        }

        public async Task<SongModel> GetSongById(int id)
        {
            var s = await _unitOfWork.Songs.GetByIdAsync(id);
            return _mapper.Map<Song, SongModel>(s);
        }

        public async Task<SongModel> UpdateSong(SongModel song)
        {
            var s = _mapper.Map<SongModel, Song>(song);
            s = _unitOfWork.Songs.Update(s);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<Song, SongModel>(s);
        }

        public async Task<IEnumerable<SongModel>> UpdateSongs(IEnumerable<SongModel> songs)
        {
            var s = _mapper.Map<IEnumerable<SongModel>, IEnumerable<Song>>(songs);
            s = _unitOfWork.Songs.UpdateRange(s);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<IEnumerable<Song>, IEnumerable<SongModel>>(s);
        }

    }
}
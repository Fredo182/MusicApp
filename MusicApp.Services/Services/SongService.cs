using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MusicApp.Data.UnitOfWork.Interfaces;
using MusicApp.Services.Models;
using MusicApp.Services.Services.Interfaces;

namespace MusicApp.Services.Services
{
    public class SongService : ISongService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SongService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Task<SongModel> CreateSong(SongModel song)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SongModel>> CreateSongs(IEnumerable<SongModel> songs)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSong(SongModel song)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSongs(IEnumerable<SongModel> songs)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SongModel>> GetAllSongs()
        {
            throw new NotImplementedException();
        }

        public Task<SongModel> GetSong(SongModel song)
        {
            throw new NotImplementedException();
        }

        public Task<SongModel> GetSongById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SongModel> UpdateSong(SongModel song)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SongModel>> UpdateSongs(IEnumerable<SongModel> songs)
        {
            throw new NotImplementedException();
        }
    }
}

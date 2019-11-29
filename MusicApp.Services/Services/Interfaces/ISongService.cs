using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MusicApp.Services.Models;

namespace MusicApp.Services.Services.Interfaces
{
    public interface ISongService
    {
        // CREATE
        Task<SongModel> CreateSong(SongModel song);
        Task<IEnumerable<SongModel>> CreateSongs(IEnumerable<SongModel> songs);

        // READ
        Task<SongModel> GetSongById(int id);
        Task<SongModel> GetSong(SongModel song);
        Task<IEnumerable<SongModel>> GetAllSongs();

        // UPDATE
        SongModel UpdateSong(SongModel song);
        IEnumerable<SongModel> UpdateSongs(IEnumerable<SongModel> songs);

        // DELETE
        void DeleteSong(SongModel song);
        void DeleteSongs(IEnumerable<SongModel> songs);
    }
}

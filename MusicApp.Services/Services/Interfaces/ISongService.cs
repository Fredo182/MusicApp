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
        Task<SongModel> UpdateSong(SongModel song);
        Task<IEnumerable<SongModel>> UpdateSongs(IEnumerable<SongModel> songs);

        // DELETE
        Task DeleteSong(SongModel song);
        Task DeleteSongs(IEnumerable<SongModel> songs);
    }
}

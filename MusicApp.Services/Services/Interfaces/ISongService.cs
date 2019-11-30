using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MusicApp.Services.Models;

namespace MusicApp.Services.Services.Interfaces
{
    public interface ISongService
    {
        // CREATE
        Task<SongModel> CreateSongAsync(SongModel song);
        Task<IEnumerable<SongModel>> CreateSongsAsync(IEnumerable<SongModel> songs);

        // READ
        Task<SongModel> GetSongByIdAsync(int id);
        Task<SongModel> GetSongAsync(SongModel song);
        Task<IEnumerable<SongModel>> GetAllSongsAsync();

        // UPDATE
        Task<SongModel> UpdateSongAsync(SongModel song);
        Task<IEnumerable<SongModel>> UpdateSongsAsync(IEnumerable<SongModel> songs);

        // DELETE
        Task DeleteSongAsync(SongModel song);
        Task DeleteSongsAsync(IEnumerable<SongModel> songs);
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MusicApp.Services.Models;

namespace MusicApp.Services.Services.Interfaces
{
    public interface IGenreService
    {
        // CREATE
        Task<GenreModel> CreateGenre(GenreModel genre);
        Task<IEnumerable<GenreModel>> CreateGenres(IEnumerable<GenreModel> genres);

        // READ
        Task<GenreModel> GetGenreById(int id);
        Task<GenreModel> GetGenre(GenreModel genre);
        Task<IEnumerable<GenreModel>> GetAllGenres();

        // UPDATE
        Task<GenreModel> UpdateGenre(GenreModel genre);
        Task<IEnumerable<GenreModel>> UpdateGenres(IEnumerable<GenreModel> genres);

        // DELETE
        Task DeleteGenre(GenreModel genre);
        Task DeleteGenres(IEnumerable<GenreModel> genres);
    }
}

﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MusicApp.Services.Models;

namespace MusicApp.Services.Services.Interfaces
{
    public interface IGenreService
    {
        // CREATE
        Task<GenreModel> CreateGenreAsync(GenreModel genre);
        Task<IEnumerable<GenreModel>> CreateGenresAsync(IEnumerable<GenreModel> genres);

        // READ
        Task<GenreModel> GetGenreByIdAsync(int id);
        Task<GenreModel> GetGenreAsync(GenreModel genre);
        Task<IEnumerable<GenreModel>> GetAllGenresAsync();

        // UPDATE
        Task<GenreModel> UpdateGenreAsync(GenreModel genre);
        Task<IEnumerable<GenreModel>> UpdateGenresAsync(IEnumerable<GenreModel> genres);

        // DELETE
        Task<bool> DeleteGenreAsync(GenreModel genre);
        Task<bool> DeleteGenreAsync(params object[] id);
        Task DeleteGenresAsync(IEnumerable<GenreModel> genres);
    }
}

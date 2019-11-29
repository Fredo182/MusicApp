using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MusicApp.Data.UnitOfWork.Interfaces;
using MusicApp.Services.Models;
using MusicApp.Services.Services.Interfaces;

namespace MusicApp.Services.Services
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenreService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Task<GenreModel> CreateGenre(GenreModel genre)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GenreModel>> CreateGenres(IEnumerable<GenreModel> genres)
        {
            throw new NotImplementedException();
        }

        public Task DeleteGenre(GenreModel genre)
        {
            throw new NotImplementedException();
        }

        public Task DeleteGenres(IEnumerable<GenreModel> genres)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GenreModel>> GetAllGenres()
        {
            throw new NotImplementedException();
        }

        public Task<GenreModel> GetGenre(GenreModel genre)
        {
            throw new NotImplementedException();
        }

        public Task<GenreModel> GetGenreById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GenreModel> UpdateGenre(GenreModel genre)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GenreModel>> UpdateGenres(IEnumerable<GenreModel> genres)
        {
            throw new NotImplementedException();
        }
    }
}

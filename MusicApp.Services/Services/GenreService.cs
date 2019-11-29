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
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GenreService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<GenreModel> CreateGenre(GenreModel genre)
        {
            var g = _mapper.Map<GenreModel, Genre>(genre);
            g = await _unitOfWork.Genres.AddAsync(g);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<Genre, GenreModel>(g);
        }

        public async Task<IEnumerable<GenreModel>> CreateGenres(IEnumerable<GenreModel> genres)
        {
            var g = _mapper.Map<IEnumerable<GenreModel>, IEnumerable<Genre>>(genres);
            g = await _unitOfWork.Genres.AddRangeAsync(g);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<IEnumerable<Genre>, IEnumerable<GenreModel>>(g);
        }

        public async Task DeleteGenre(GenreModel genre)
        {
            var g = _mapper.Map<GenreModel, Genre>(genre);
            _unitOfWork.Genres.Delete(g);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteGenres(IEnumerable<GenreModel> genres)
        {
            var g = _mapper.Map<IEnumerable<GenreModel>, IEnumerable<Genre>>(genres);
            _unitOfWork.Genres.DeleteRange(g);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<GenreModel>> GetAllGenres()
        {
            var g = await _unitOfWork.Genres.GetAsync();
            return _mapper.Map<IEnumerable<Genre>, IEnumerable<GenreModel>>(g);
        }

        public async Task<GenreModel> GetGenre(GenreModel genre)
        {
            //TODO: This one needs to be updated to use filtering
            var g = _mapper.Map<GenreModel, Genre>(genre);
            g = await _unitOfWork.Genres.GetByIdAsync(g.GenreId);
            return _mapper.Map<Genre, GenreModel>(g);
        }

        public async Task<GenreModel> GetGenreById(int id)
        {
            var g = await _unitOfWork.Genres.GetByIdAsync(id);
            return _mapper.Map<Genre, GenreModel>(g);
        }

        public async Task<GenreModel> UpdateGenre(GenreModel genre)
        {
            var g = _mapper.Map<GenreModel, Genre>(genre);
            g = _unitOfWork.Genres.Update(g);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<Genre, GenreModel>(g);
        }

        public async Task<IEnumerable<GenreModel>> UpdateGenres(IEnumerable<GenreModel> genres)
        {
            var g = _mapper.Map<IEnumerable<GenreModel>, IEnumerable<Genre>>(genres);
            g = _unitOfWork.Genres.UpdateRange(g);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<IEnumerable<Genre>, IEnumerable<GenreModel>>(g);
        }
    }
}

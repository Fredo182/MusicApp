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

        public GenreService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<GenreModel> CreateGenreAsync(GenreModel genre)
        {
            var g = _mapper.Map<GenreModel, Genre>(genre);
            g = await _unitOfWork.Genres.AddAsync(g);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<Genre, GenreModel>(g);
        }

        public async Task<IEnumerable<GenreModel>> CreateGenresAsync(IEnumerable<GenreModel> genres)
        {
            var g = _mapper.Map<IEnumerable<GenreModel>, IEnumerable<Genre>>(genres);
            g = await _unitOfWork.Genres.AddRangeAsync(g);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<IEnumerable<Genre>, IEnumerable<GenreModel>>(g);
        }

        public async Task DeleteGenreAsync(GenreModel genre)
        {
            var g = _mapper.Map<GenreModel, Genre>(genre);
            _unitOfWork.Genres.Delete(g);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteGenresAsync(IEnumerable<GenreModel> genres)
        {
            var g = _mapper.Map<IEnumerable<GenreModel>, IEnumerable<Genre>>(genres);
            _unitOfWork.Genres.DeleteRange(g);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<GenreModel>> GetAllGenresAsync()
        {
            var g = await _unitOfWork.Genres.GetAsync();
            return _mapper.Map<IEnumerable<Genre>, IEnumerable<GenreModel>>(g);
        }

        public async Task<GenreModel> GetGenreAsync(GenreModel genre)
        {
            //TODO: This one needs to be updated to use filtering
            var g = _mapper.Map<GenreModel, Genre>(genre);
            g = await _unitOfWork.Genres.GetByIdAsync(g.GenreId);
            return _mapper.Map<Genre, GenreModel>(g);
        }

        public async Task<GenreModel> GetGenreByIdAsync(int id)
        {
            var g = await _unitOfWork.Genres.GetByIdAsync(id);
            return _mapper.Map<Genre, GenreModel>(g);
        }

        public async Task<bool> GenreExistsAsync(int id)
        {
            var g = await _unitOfWork.Genres.ExistsAsync(g => g.GenreId == id);
            return g;
        }

        public async Task<GenreModel> UpdateGenreAsync(GenreModel genre)
        {
            var g = _mapper.Map<GenreModel, Genre>(genre);
            g = _unitOfWork.Genres.Update(g);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<Genre, GenreModel>(g);
        }

        public async Task<IEnumerable<GenreModel>> UpdateGenresAsync(IEnumerable<GenreModel> genres)
        {
            var g = _mapper.Map<IEnumerable<GenreModel>, IEnumerable<Genre>>(genres);
            g = _unitOfWork.Genres.UpdateRange(g);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<IEnumerable<Genre>, IEnumerable<GenreModel>>(g);
        }
    }
}

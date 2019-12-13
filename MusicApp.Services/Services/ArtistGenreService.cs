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
    public class ArtistGenreService : IArtistGenreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ArtistGenreService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<ArtistGenreModel> CreateArtistGenreAsync(ArtistGenreModel artistGenre)
        {
            var a = _mapper.Map<ArtistGenre>(artistGenre);
            a = await _unitOfWork.ArtistGenres.AddAsync(a);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<ArtistGenreModel>(a);
        }

        public async Task<IEnumerable<ArtistGenreModel>> CreateArtistGenresAsync(IEnumerable<ArtistGenreModel> artistGenres)
        {
            var a = _mapper.Map<IEnumerable<ArtistGenre>>(artistGenres);
            a = await _unitOfWork.ArtistGenres.AddRangeAsync(a);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<IEnumerable<ArtistGenreModel>>(a);
        }

        public async Task<bool> DeleteArtistGenreAsync(ArtistGenreModel artistGenre)
        {
            var a = _mapper.Map<ArtistGenre>(artistGenre);
            _unitOfWork.ArtistGenres.Delete(a);
            var deleted = await _unitOfWork.CommitAsync();
            return deleted > 0;
        }

        public async Task<bool> DeleteArtistGenreAsync(params object[] id)
        {
            _unitOfWork.ArtistGenres.Delete(id);
            var deleted = await _unitOfWork.CommitAsync();
            return deleted > 0;
        }

        public async Task DeleteArtistGenresAsync(IEnumerable<ArtistGenreModel> artistGenres)
        {
            var a = _mapper.Map<IEnumerable<ArtistGenre>>(artistGenres);
            _unitOfWork.ArtistGenres.DeleteRange(a);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<ArtistGenreModel>> GetAllArtistGenresAsync()
        {
            var a = await _unitOfWork.ArtistGenres.GetAsync();
            return _mapper.Map<IEnumerable<ArtistGenreModel>>(a);
        }

        public async Task<ArtistGenreModel> GetArtistGenreAsync(ArtistGenreModel artistGenre)
        {
            var a = _mapper.Map<ArtistGenre>(artistGenre);
            a = await _unitOfWork.ArtistGenres.GetByIdAsync(a.ArtistGenreId);
            return _mapper.Map<ArtistGenreModel>(a);
        }

        public async Task<ArtistGenreModel> GetArtistGenreByIdAsync(int id)
        {
            var a = await _unitOfWork.ArtistGenres.GetByIdAsync(id);
            return _mapper.Map<ArtistGenreModel>(a);
        }


        public async Task<ArtistGenreModel> UpdateArtistGenreAsync(ArtistGenreModel artistGenre)
        {
            var a = _mapper.Map<ArtistGenre>(artistGenre);
            a = _unitOfWork.ArtistGenres.Update(a);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<ArtistGenreModel>(a);
        }

        public async Task<IEnumerable<ArtistGenreModel>> UpdateArtistGenresAsync(IEnumerable<ArtistGenreModel> artistGenres)
        {
            var a = _mapper.Map<IEnumerable<ArtistGenre>>(artistGenres);
            a = _unitOfWork.ArtistGenres.UpdateRange(a);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<IEnumerable<ArtistGenreModel>>(a);
        }
    }
}

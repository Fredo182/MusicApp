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
            var a = _mapper.Map<ArtistGenreModel, ArtistGenre>(artistGenre);
            a = await _unitOfWork.ArtistGenres.AddAsync(a);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<ArtistGenre, ArtistGenreModel>(a);
        }

        public async Task<IEnumerable<ArtistGenreModel>> CreateArtistGenresAsync(IEnumerable<ArtistGenreModel> artistGenres)
        {
            var a = _mapper.Map<IEnumerable<ArtistGenreModel>, IEnumerable<ArtistGenre>>(artistGenres);
            a = await _unitOfWork.ArtistGenres.AddRangeAsync(a);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<IEnumerable<ArtistGenre>, IEnumerable<ArtistGenreModel>>(a);
        }

        public async Task DeleteArtistGenreAsync(ArtistGenreModel artistGenre)
        {
            var a = _mapper.Map<ArtistGenreModel, ArtistGenre>(artistGenre);
            _unitOfWork.ArtistGenres.Delete(a);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteArtistGenresAsync(IEnumerable<ArtistGenreModel> artistGenres)
        {
            var a = _mapper.Map<IEnumerable<ArtistGenreModel>, IEnumerable<ArtistGenre>>(artistGenres);
            _unitOfWork.ArtistGenres.DeleteRange(a);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<ArtistGenreModel>> GetAllArtistGenresAsync()
        {
            var a = await _unitOfWork.ArtistGenres.GetAsync();
            return _mapper.Map<IEnumerable<ArtistGenre>, IEnumerable<ArtistGenreModel>>(a);
        }

        public async Task<ArtistGenreModel> GetArtistGenreAsync(ArtistGenreModel artistGenre)
        {
            //TODO: This one needs to be updated to use filtering
            var a = _mapper.Map<ArtistGenreModel, ArtistGenre>(artistGenre);
            a = await _unitOfWork.ArtistGenres.GetByIdAsync(a.ArtistGenreId);
            return _mapper.Map<ArtistGenre, ArtistGenreModel>(a);
        }

        public async Task<ArtistGenreModel> GetArtistGenreByIdAsync(int id)
        {
            var a = await _unitOfWork.ArtistGenres.GetByIdAsync(id);
            return _mapper.Map<ArtistGenre, ArtistGenreModel>(a);
        }

        public async Task<bool> ArtistGenreExistsAsync(int id)
        {
            var a = await _unitOfWork.ArtistGenres.ExistsAsync(a => a.ArtistGenreId == id);
            return a;
        }

        public async Task<ArtistGenreModel> UpdateArtistGenreAsync(ArtistGenreModel artistGenre)
        {
            var a = _mapper.Map<ArtistGenreModel, ArtistGenre>(artistGenre);
            a = _unitOfWork.ArtistGenres.Update(a);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<ArtistGenre, ArtistGenreModel>(a);
        }

        public async Task<IEnumerable<ArtistGenreModel>> UpdateArtistGenresAsync(IEnumerable<ArtistGenreModel> artistGenres)
        {
            var a = _mapper.Map<IEnumerable<ArtistGenreModel>, IEnumerable<ArtistGenre>>(artistGenres);
            a = _unitOfWork.ArtistGenres.UpdateRange(a);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<IEnumerable<ArtistGenre>, IEnumerable<ArtistGenreModel>>(a);
        }
    }
}

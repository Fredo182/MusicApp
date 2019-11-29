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

        public ArtistGenreService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<ArtistGenreModel> CreateArtistGenre(ArtistGenreModel artistGenre)
        {
            var a = _mapper.Map<ArtistGenreModel, ArtistGenre>(artistGenre);
            a = await _unitOfWork.ArtistGenres.AddAsync(a);
            return _mapper.Map<ArtistGenre, ArtistGenreModel>(a);
        }

        public async Task<IEnumerable<ArtistGenreModel>> CreateArtistGenres(IEnumerable<ArtistGenreModel> artistGenres)
        {
            var a = _mapper.Map<IEnumerable<ArtistGenreModel>, IEnumerable<ArtistGenre>>(artistGenres);
            a = await _unitOfWork.ArtistGenres.AddRangeAsync(a);
            return _mapper.Map<IEnumerable<ArtistGenre>, IEnumerable<ArtistGenreModel>>(a);
        }

        public void DeleteArtistGenre(ArtistGenreModel artistGenre)
        {
            var a = _mapper.Map<ArtistGenreModel, ArtistGenre>(artistGenre);
            _unitOfWork.ArtistGenres.Delete(a);
        }

        public void DeleteArtistGenres(IEnumerable<ArtistGenreModel> artistGenres)
        {
            var a = _mapper.Map<IEnumerable<ArtistGenreModel>, IEnumerable<ArtistGenre>>(artistGenres);
            _unitOfWork.ArtistGenres.DeleteRange(a);
        }

        public async Task<IEnumerable<ArtistGenreModel>> GetAllArtistGenres()
        {
            var a = await _unitOfWork.ArtistGenres.GetAsync();
            return _mapper.Map<IEnumerable<ArtistGenre>, IEnumerable<ArtistGenreModel>>(a);
        }

        public async Task<ArtistGenreModel> GetArtistGenre(ArtistGenreModel artistGenre)
        {
            //TODO: This one needs to be updated to use filtering
            var a = _mapper.Map<ArtistGenreModel, ArtistGenre>(artistGenre);
            a = await _unitOfWork.ArtistGenres.GetByIdAsync(a.ArtistGenreId);
            return _mapper.Map<ArtistGenre, ArtistGenreModel>(a);
        }

        public async Task<ArtistGenreModel> GetArtistGenreById(int id)
        {
            var a = await _unitOfWork.ArtistGenres.GetByIdAsync(id);
            return _mapper.Map<ArtistGenre, ArtistGenreModel>(a);
        }

        public ArtistGenreModel UpdateArtistGenre(ArtistGenreModel artistGenre)
        {
            var a = _mapper.Map<ArtistGenreModel, ArtistGenre>(artistGenre);
            a = _unitOfWork.ArtistGenres.Update(a);
            return _mapper.Map<ArtistGenre, ArtistGenreModel>(a);
        }

        public IEnumerable<ArtistGenreModel> UpdateArtistGenres(IEnumerable<ArtistGenreModel> artistGenres)
        {
            var a = _mapper.Map<IEnumerable<ArtistGenreModel>, IEnumerable<ArtistGenre>>(artistGenres);
            a = _unitOfWork.ArtistGenres.UpdateRange(a);
            return _mapper.Map<IEnumerable<ArtistGenre>, IEnumerable<ArtistGenreModel>>(a);
        }
    }
}

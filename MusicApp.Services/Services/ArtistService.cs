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
    public class ArtistService : IArtistService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ArtistService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<ArtistModel> CreateArtist(ArtistModel artist)
        {
            var a = _mapper.Map<ArtistModel, Artist>(artist);
            a = await _unitOfWork.Artists.AddAsync(a);
            return _mapper.Map<Artist, ArtistModel>(a);
        }

        public async Task<IEnumerable<ArtistModel>> CreateArtists(IEnumerable<ArtistModel> artists)
        {
            var a = _mapper.Map<IEnumerable<ArtistModel>, IEnumerable<Artist>>(artists);
            a = await _unitOfWork.Artists.AddRangeAsync(a);
            return _mapper.Map<IEnumerable<Artist>, IEnumerable<ArtistModel>>(a);
        }

        public void DeleteArtist(ArtistModel artist)
        {
            var a = _mapper.Map<ArtistModel, Artist>(artist);
            _unitOfWork.Artists.Delete(a);
        }

        public void DeleteArtists(IEnumerable<ArtistModel> artists)
        {
            var a = _mapper.Map<IEnumerable<ArtistModel>, IEnumerable<Artist>>(artists);
            _unitOfWork.Artists.DeleteRange(a);
        }

        public async Task<IEnumerable<ArtistModel>> GetAllArtists()
        {
            var a = await _unitOfWork.Artists.GetAsync();
            return _mapper.Map<IEnumerable<Artist>, IEnumerable<ArtistModel>>(a);
        }

        public async Task<ArtistModel> GetArtist(ArtistModel artist)
        {
            //TODO: This one needs to be updated to use filtering
            var a = _mapper.Map<ArtistModel, Artist>(artist);
            a = await _unitOfWork.Artists.GetByIdAsync(a.ArtistId);
            return _mapper.Map<Artist, ArtistModel>(a);
        }

        public async Task<ArtistModel> GetArtistById(int id)
        {
            var a = await _unitOfWork.Artists.GetByIdAsync(id);
            return _mapper.Map<Artist, ArtistModel>(a);
        }

        public ArtistModel UpdateArtist(ArtistModel artist)
        {
            var a = _mapper.Map<ArtistModel, Artist>(artist);
            a = _unitOfWork.Artists.Update(a);
            return _mapper.Map<Artist, ArtistModel>(a);
        }

        public IEnumerable<ArtistModel> UpdateArtists(IEnumerable<ArtistModel> artists)
        {
            var a = _mapper.Map<IEnumerable<ArtistModel>, IEnumerable<Artist>>(artists);
            a = _unitOfWork.Artists.UpdateRange(a);
            return _mapper.Map<IEnumerable<Artist>, IEnumerable<ArtistModel>>(a);
        }
    }
}

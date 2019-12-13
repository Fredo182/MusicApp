﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public ArtistService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<ArtistModel> CreateArtistAsync(ArtistModel artist)
        {
            var a = _mapper.Map<Artist>(artist);
            a = await _unitOfWork.Artists.AddAsync(a);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<ArtistModel>(a);
        }

        public async Task<IEnumerable<ArtistModel>> CreateArtistsAsync(IEnumerable<ArtistModel> artists)
        {
            var a = _mapper.Map<IEnumerable<Artist>>(artists);
            a = await _unitOfWork.Artists.AddRangeAsync(a);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<IEnumerable<ArtistModel>>(a);
        }

        public async Task<bool> DeleteArtistAsync(ArtistModel artist)
        {
            var a = _mapper.Map<Artist>(artist);
            _unitOfWork.Artists.Delete(a);
            var deleted = await _unitOfWork.CommitAsync();
            return deleted > 0;
        }

        public async Task<bool> DeleteArtistAsync(params object[] id)
        {
            _unitOfWork.Artists.Delete(id);
            var deleted = await _unitOfWork.CommitAsync();
            return deleted > 0;
        }

        public async Task DeleteArtistsAsync(IEnumerable<ArtistModel> artists)
        {
            var a = _mapper.Map<IEnumerable<Artist>>(artists);
            _unitOfWork.Artists.DeleteRange(a);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<ArtistModel>> GetAllArtistsAsync()
        {
            var a = await _unitOfWork.Artists.GetAsync();
            return _mapper.Map<IEnumerable<ArtistModel>>(a);
        }

        public async Task<ArtistModel> GetArtistAsync(ArtistModel artist)
        {
            var a = _mapper.Map<Artist>(artist);
            a = await _unitOfWork.Artists.GetByIdAsync(a.ArtistId);
            return _mapper.Map<ArtistModel>(a);
        }

        public async Task<ArtistModel> GetArtistByIdAsync(int id)
        {
            var a = await _unitOfWork.Artists.GetByIdAsync(id);
            return _mapper.Map<ArtistModel>(a);
        }

        public async Task<ArtistModel> UpdateArtistAsync(ArtistModel artist)
        {
            var a = _mapper.Map<Artist>(artist);
            a = _unitOfWork.Artists.Update(a);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<ArtistModel>(a);
        }

        public async Task<IEnumerable<ArtistModel>> UpdateArtistsAsync(IEnumerable<ArtistModel> artists)
        {
            var a = _mapper.Map<IEnumerable<Artist>>(artists);
            a = _unitOfWork.Artists.UpdateRange(a);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<IEnumerable<ArtistModel>>(a);
        }

        public async Task<bool> ArtistIdExistsAsync(int id)
        {
            var a = await _unitOfWork.Artists.SingleOrDefaultAsync((x => x.ArtistId == id), false);
            return (a != null);
        }

        public async Task<bool> ArtistExistsAsync(ArtistModel artist)
        {
            var a = _mapper.Map<Artist>(artist);
            a = await _unitOfWork.Artists.SingleOrDefaultAsync((x => x.ArtistId == a.ArtistId), false);
            return (a != null);
        }

        public async Task<IEnumerable<ArtistModel>> ArtistsExistAsync(IEnumerable<ArtistModel> artists)
        {
            var a = _mapper.Map<IEnumerable<Artist>>(artists);
            var ids = a.Select(x => x.ArtistId).ToList();
            var exist = await _unitOfWork.Artists.GetAsync(x => ids.Contains(x.ArtistId), null, null, false);
            return _mapper.Map<IEnumerable<ArtistModel>>(exist);
        }

        public async Task<bool> ArtistNameExistsAsync(string name)
        {
            var a = await _unitOfWork.Artists.SingleOrDefaultAsync((x => x.Name == name), false);
            return (a != null);
        }

        public async Task<bool> ArtistNameExistsAsync(ArtistModel artist)
        {
            var a = _mapper.Map<Artist>(artist);
            a = await _unitOfWork.Artists.SingleOrDefaultAsync((x => x.Name == a.Name), false);
            return (a != null);
        }

        public async Task<IEnumerable<ArtistModel>> ArtistNamesExistsAsync(IEnumerable<ArtistModel> artists)
        {
            var a = _mapper.Map<IEnumerable<Artist>>(artists);
            var names = a.Select(x => x.Name).ToList();
            var exist = await _unitOfWork.Artists.GetAsync((x => names.Contains(x.Name)), null, null, false);
            return _mapper.Map<IEnumerable<ArtistModel>>(exist);
        }
    }
}

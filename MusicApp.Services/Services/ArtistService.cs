using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MusicApp.Data.UnitOfWork.Interfaces;
using MusicApp.Services.Models;
using MusicApp.Services.Services.Interfaces;

namespace MusicApp.Services.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArtistService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Task<ArtistModel> CreateArtist(ArtistModel artist)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ArtistModel>> CreateArtists(IEnumerable<ArtistModel> artists)
        {
            throw new NotImplementedException();
        }

        public Task DeleteArtist(ArtistModel artist)
        {
            throw new NotImplementedException();
        }

        public Task DeleteArtists(IEnumerable<ArtistModel> artists)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ArtistModel>> GetAllArtists()
        {
            throw new NotImplementedException();
        }

        public Task<ArtistModel> GetArtist(ArtistModel artist)
        {
            throw new NotImplementedException();
        }

        public Task<ArtistModel> GetArtistById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ArtistModel> UpdateArtist(ArtistModel artist)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ArtistModel>> UpdateArtists(IEnumerable<ArtistModel> artist)
        {
            throw new NotImplementedException();
        }
    }
}

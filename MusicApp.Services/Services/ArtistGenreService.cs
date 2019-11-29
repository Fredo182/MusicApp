using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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

        public Task<ArtistGenreModel> CreateArtistGenre(ArtistGenreModel artistGenre)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ArtistGenreModel>> CreateArtistGenres(IEnumerable<ArtistGenreModel> artistGenres)
        {
            throw new NotImplementedException();
        }

        public void DeleteArtistGenre(ArtistGenreModel artistGenre)
        {
            throw new NotImplementedException();
        }

        public void DeleteArtistGenres(IEnumerable<ArtistGenreModel> artistGenres)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ArtistGenreModel>> GetAllAlbums()
        {
            throw new NotImplementedException();
        }

        public Task<ArtistGenreModel> GetArtistGenre(ArtistGenreModel artistGenre)
        {
            throw new NotImplementedException();
        }

        public Task<ArtistGenreModel> GetArtistGenreById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ArtistGenreModel> UpdateArtistGenre(ArtistGenreModel artistGenre)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ArtistGenreModel>> UpdateArtistGenres(IEnumerable<ArtistGenreModel> artistGenres)
        {
            throw new NotImplementedException();
        }
    }
}

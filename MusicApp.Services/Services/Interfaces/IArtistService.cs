using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MusicApp.Services.Models;

namespace MusicApp.Services.Services.Interfaces
{
    public interface IArtistService
    {
        // CREATE
        Task<ArtistModel> CreateArtist(ArtistModel artist);
        Task<IEnumerable<ArtistModel>> CreateArtists(IEnumerable<ArtistModel> artists);

        // READ
        Task<ArtistModel> GetArtistById(int id);
        Task<ArtistModel> GetArtist(ArtistModel artist);
        Task<IEnumerable<ArtistModel>> GetAllArtists();

        // UPDATE
        ArtistModel UpdateArtist(ArtistModel artist);
        IEnumerable<ArtistModel> UpdateArtists(IEnumerable<ArtistModel> artists);

        // DELETE
        void DeleteArtist(ArtistModel artist);
        void DeleteArtists(IEnumerable<ArtistModel> artists);
    }
}

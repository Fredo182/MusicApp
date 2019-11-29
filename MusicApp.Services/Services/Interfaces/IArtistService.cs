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
        Task<ArtistModel> UpdateArtist(ArtistModel artist);
        Task<IEnumerable<ArtistModel>> UpdateArtists(IEnumerable<ArtistModel> artist);

        // DELETE
        Task DeleteArtist(ArtistModel artist);
        Task DeleteArtists(IEnumerable<ArtistModel> artists);
    }
}

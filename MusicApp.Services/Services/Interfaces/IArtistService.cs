using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MusicApp.Services.Models;

namespace MusicApp.Services.Services.Interfaces
{
    public interface IArtistService
    {
        // CREATE
        Task<ArtistModel> CreateArtistAsync(ArtistModel artist);
        Task<IEnumerable<ArtistModel>> CreateArtistsAsync(IEnumerable<ArtistModel> artists);

        // READ
        Task<ArtistModel> GetArtistByIdAsync(int id);
        Task<ArtistModel> GetArtistAsync(ArtistModel artist);
        Task<IEnumerable<ArtistModel>> GetAllArtistsAsync();

        // UPDATE
        Task<ArtistModel> UpdateArtistAsync(ArtistModel artist);
        Task<IEnumerable<ArtistModel>> UpdateArtistsAsync(IEnumerable<ArtistModel> artists);

        // DELETE
        Task DeleteArtistAsync(ArtistModel artist);
        Task DeleteArtistsAsync(IEnumerable<ArtistModel> artists);

        // Other
        Task<bool> ArtistExistsAsync(int id);
    }
}

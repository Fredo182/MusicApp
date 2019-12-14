using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MusicApp.Services.Helpers;
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
        Task<IEnumerable<ArtistModel>> GetArtistsAsync();
        Task<PagedResultModel<ArtistModel>> GetPagedArtistsAsync(PaginationModel pagination);

        // UPDATE
        Task<ArtistModel> UpdateArtistAsync(ArtistModel artist);
        Task<IEnumerable<ArtistModel>> UpdateArtistsAsync(IEnumerable<ArtistModel> artists);

        // DELETE
        Task<bool> DeleteArtistAsync(ArtistModel artist);
        Task<bool> DeleteArtistAsync(params object[] id);
        Task<bool> DeleteArtistsAsync(int[] ids);
        Task<bool> DeleteArtistsAsync(IEnumerable<ArtistModel> artists);

        // EXIST
        // IDs
        Task<bool> ArtistIdExistsAsync(int id);
        Task<bool> ArtistIdsExistAsync(int[] ids);
        Task<bool> ArtistExistsAsync(ArtistModel artist);
        Task<IEnumerable<ArtistModel>> ArtistsExistAsync(IEnumerable<ArtistModel> artists);
        Task<IEnumerable<ArtistModel>> ArtistsNotExistAsync(IEnumerable<ArtistModel> artists);

        // UNIQUE
        Task<bool> ArtistNameExistsAsync(string name);
        Task<bool> ArtistNameExistsAsync(ArtistModel artist);
        Task<IEnumerable<ArtistModel>> ArtistNamesExistsAsync(IEnumerable<ArtistModel> artists);

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MusicApp.Services.Models.Shared;
using MusicApp.Services.Models;
using MusicApp.Services.Models.Queries.Shared;
using MusicApp.Services.Models.Queries;

namespace MusicApp.Services.Services.Interfaces
{
    public interface IArtistService
    {
        // CREATE
        Task<ArtistModel> CreateArtistAsync(ArtistModel artist);
        Task<IEnumerable<ArtistModel>> CreateArtistsAsync(IEnumerable<ArtistModel> artists);

        // READ
        Task<ArtistModel> GetArtistByIdAsync(int id, string includes = "", bool tracking = true);
        Task<ArtistModel> GetArtistAsync(ArtistModel artist, string includes = "", bool tracking = true);
        Task<IEnumerable<ArtistModel>> GetArtistsAsync(ArtistFilterModel filter = null, IEnumerable<ArtistOrderByModel> orderByList = null, string includes = "", bool tracking = true);
        Task<PaginationResultModel<ArtistModel>> GetPagedArtistsAsync(PaginationModel pagination, ArtistFilterModel filter = null, IEnumerable<ArtistOrderByModel> orderByList = null, string includes ="", bool tracking = true);

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

        // READ WITH INCLUDES
        Task<ArtistModel> GetArtistAlbumsAsync(int id, bool tracking = true);
        Task<ArtistModel> GetArtistAlbumsSongsAsync(int id, bool tracking = true);
        Task<IEnumerable<ArtistModel>> GetArtistsAlbumsAsync(ArtistFilterModel filter = null, IEnumerable<ArtistOrderByModel> orderByList = null, bool tracking = true);
        Task<PaginationResultModel<ArtistModel>> GetPagedArtistsAlbumsAsync(PaginationModel pagination, ArtistFilterModel filter = null, IEnumerable<ArtistOrderByModel> orderByList = null, bool tracking = true);
        Task<IEnumerable<ArtistModel>> GetArtistsAlbumsSongsAsync(ArtistFilterModel filter = null, IEnumerable<ArtistOrderByModel> orderByList = null, bool tracking = true);
        Task<PaginationResultModel<ArtistModel>> GetPagedArtistsAlbumsSongsAsync(PaginationModel pagination, ArtistFilterModel filter = null, IEnumerable<ArtistOrderByModel> orderByList = null, bool tracking = true);

    }
}

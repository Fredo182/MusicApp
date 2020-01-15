using System;
using AutoMapper;
using MusicApp.API.Contracts.V1.Responses.AccountsResponses;
using MusicApp.API.Contracts.V1.Responses.AlbumsResponses;
using MusicApp.API.Contracts.V1.Responses.ArtistsResponses;
using MusicApp.API.Contracts.V1.Responses.SongsReponses;
using MusicApp.Services.Models;
using MusicApp.Services.Services.Responses;

namespace MusicApp.API.Mapping
{
    public class ModelToResponseProfile : Profile
    {
        public ModelToResponseProfile()
        {
            // Service Responses
            CreateMap<AccountServiceResponse, AccountLoginResponse>();
            CreateMap<AccountServiceResponse, AccountRefreshResponse>();

            // Artists Mappings
            CreateMap<ArtistModel, ArtistResponse>();
            CreateMap<ArtistModel, ArtistAlbumsResponse>();
            CreateMap<ArtistModel, ArtistAlbumsSongsResponse>();

            // Albums Mappings
            CreateMap<AlbumModel, AlbumResponse>();
            CreateMap<AlbumModel, AlbumSongsResponse>();

            // Songs Mappings
            CreateMap<SongModel, SongResponse>();
        }
    }
}

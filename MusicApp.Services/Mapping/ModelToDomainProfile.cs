using System;
using AutoMapper;
using MusicApp.Data.Domain;
using MusicApp.Data.Domain.Authorization;
using MusicApp.Data.Domain.Queries;
using MusicApp.Data.Domain.Queries.Shared;
using MusicApp.Services.Models;
using MusicApp.Services.Models.Authorization;
using MusicApp.Services.Models.Queries;
using MusicApp.Services.Models.Queries.Shared;

namespace MusicApp.Services.Mapping
{
    public class ModelToDomainProfile : Profile
    {
        public ModelToDomainProfile()
        {
            //Shared Queries
            CreateMap<PaginationModel, Pagination>();

            //Queries
            CreateMap<ArtistFilterModel, ArtistFilter>();
            CreateMap<ArtistOrderByModel, ArtistOrderBy>();

            //Authorization
            CreateMap<UserModel, User>();
            CreateMap<RoleModel, Role>();
            CreateMap<UserClaimModel, UserClaim>();
            CreateMap<UserLoginModel, UserLogin>();
            CreateMap<UserRoleModel, UserRole>();
            CreateMap<UserTokenModel, UserToken>();
            CreateMap<RoleClaimModel, RoleClaim>();

            // Model to Domain
            CreateMap<AlbumModel, Album>();
            CreateMap<ArtistGenreModel, ArtistGenre>();
            CreateMap<ArtistModel, Artist>();
            CreateMap<GenreModel, Genre>();
            CreateMap<SongModel, Song>();
            CreateMap<PlaylistModel, Playlist>();
        }
    }
}

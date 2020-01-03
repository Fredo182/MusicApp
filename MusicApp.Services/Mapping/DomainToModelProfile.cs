using System;
using AutoMapper;
using MusicApp.Data.Domain;
using MusicApp.Data.Domain.Authorization;
using MusicApp.Data.Domain.Shared;
using MusicApp.Services.Models;
using MusicApp.Services.Models.Authorization;
using MusicApp.Services.Models.Shared;

namespace MusicApp.Services.Mapping
{
    public class DomainToModelProfile : Profile
    {
        public DomainToModelProfile()
        {
            //Shared
            CreateMap<PaginationState, PaginationStateModel>();

            // Authorization
            CreateMap<User, UserModel>();
            CreateMap<Role, RoleModel>();
            CreateMap<UserRole, UserRoleModel>();
            CreateMap<UserClaim, UserClaimModel>();
            CreateMap<UserLogin, UserLoginModel>();
            CreateMap<UserToken, UserTokenModel>();
            CreateMap<RoleClaim, RoleClaimModel>();

            // Domain to Model
            CreateMap<Album, AlbumModel>();
            CreateMap<ArtistGenre, ArtistGenreModel>();
            CreateMap<Artist, ArtistModel>();
            CreateMap<Genre, GenreModel>();
            CreateMap<Song, SongModel>();
            CreateMap<Playlist, PlaylistModel>();

        }
    }
}

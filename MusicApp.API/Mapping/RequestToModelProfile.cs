using System;
using AutoMapper;
using MusicApp.API.Contracts.V1.Requests.AccountsRequests;
using MusicApp.API.Contracts.V1.Requests.ArtistsRequests;
using MusicApp.Services.Models;
using MusicApp.Services.Models.Authorization;

namespace MusicApp.API.Mapping
{
    public class RequestToModelProfile : Profile
    {
        public RequestToModelProfile()
        {
            // Account Mappings
            CreateMap<AccountRegisterRequest, UserModel>();
            CreateMap<AccountLoginRequest, UserModel>();

            // Artists Mappings
            CreateMap<ArtistCreateRequest, ArtistModel>();
            CreateMap<ArtistUpdateRequest, ArtistModel>();
        }
    }
}

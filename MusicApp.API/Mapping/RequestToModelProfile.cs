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
            CreateMap<AccountRegisterRequest, UserModel>()
                //UserName will be the same as the email address
                .ForMember(x => x.UserName, opt => opt.MapFrom( d => d.Email ));
            CreateMap<AccountLoginRequest, UserModel>();

            // Artists Mappings
            CreateMap<ArtistCreateRequest, ArtistModel>();
            CreateMap<ArtistUpdateRequest, ArtistModel>();
        }
    }
}

using System;
using AutoMapper;
using MusicApp.API.Contracts.V1.Requests.ArtistsRequests;
using MusicApp.API.Contracts.V1.Requests.Queries;
using MusicApp.Services.Models;

namespace MusicApp.API.Mapping
{
    public class RequestToModelProfile : Profile
    {
        public RequestToModelProfile()
        {
            // Artists Mappings
            CreateMap<CreateArtistRequest, ArtistModel>();
            CreateMap<UpdateArtistRequest, ArtistModel>();
        }
    }
}

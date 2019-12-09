using System;
using AutoMapper;
using MusicApp.API.Contracts.V1.Requests.ArtistsRequests;
using MusicApp.API.Contracts.V1.Requests.Queries;
using MusicApp.Services.Models;
using MusicApp.Services.Models.Shared;

namespace MusicApp.API.Mapping
{
    public class RequestToModelProfile : Profile
    {
        public RequestToModelProfile()
        {
            CreateMap<PaginationQuery, PaginationFilter>();

            // Artists Mappings
            CreateMap<CreateArtistRequest, ArtistModel>();
        }
    }
}

using System;
using AutoMapper;
using MusicApp.API.Contracts.V1.Responses.ArtistsResponses;
using MusicApp.Services.Models;

namespace MusicApp.API.Mapping
{
    public class ModelToResponseProfile : Profile
    {
        public ModelToResponseProfile()
        {
            // Artists Mappings
            CreateMap<ArtistModel, ArtistResponse>();
            CreateMap<ArtistResponse, ArtistModel>();
        }
    }
}

using System;
using AutoMapper;
using MusicApp.API.Contracts.V1.Requests.Queries;
using MusicApp.Services.Helpers;

namespace MusicApp.API.Mapping
{
    public class HelpersProfile : Profile
    {
        public HelpersProfile()
        {
            CreateMap<PaginationQuery, PaginationModel>();
        }
    }
}

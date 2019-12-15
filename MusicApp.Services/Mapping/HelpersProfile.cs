using System;
using AutoMapper;
using MusicApp.Data.Domain.Queries.Shared;
using MusicApp.Services.Models.Queries.Shared;

namespace MusicApp.Services.Mapping
{
    public class HelpersProfile : Profile
    {
        public HelpersProfile()
        {
            CreateMap<Pagination, PaginationModel>();
            CreateMap<PaginationModel, Pagination>();
        }
    }
}

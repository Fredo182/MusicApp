using System;
using AutoMapper;
using MusicApp.Data.Domain.Shared;
using MusicApp.Services.Models.Shared;

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

using System;
using AutoMapper;
using MusicApp.Data.Helpers;
using MusicApp.Services.Helpers;

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

using System;
using AutoMapper;
using MusicApp.API.Contracts.V1.Requests.Queries.Shared;
using MusicApp.Services.Models.Shared;

namespace MusicApp.API.Mapping
{
    public class OrderyByQueryResolver : IValueResolver<OrderByQuery, OrderByModel, string>
    {
        public string Resolve(OrderByQuery source, OrderByModel destination, string member, ResolutionContext context)
        {
            if (((source.OrderBy[0] == '+') || (source.OrderBy[0] == '-')) && source.OrderBy.Length > 1)
                return source.OrderBy.Substring(1);
            else
                return source.OrderBy;
        }
    }

    public class OrderyByTypeQueryResolver : IValueResolver<OrderByQuery, OrderByModel, string>
    {
        public string Resolve(OrderByQuery source, OrderByModel destination, string member, ResolutionContext context)
        {
            if (source.OrderBy[0] == '-')
                return "desc";
            else
                return "asc";
        }
    }

    public class HelpersProfile : Profile
    {
        public HelpersProfile()
        {
            CreateMap<PaginationQuery, PaginationModel>();
            CreateMap<OrderByQuery, OrderByModel>()
                .ForMember(dest => dest.OrderBy, opt => {
                    opt.PreCondition(src => !string.IsNullOrEmpty(src.OrderBy));
                    opt.MapFrom<OrderyByQueryResolver>();
                })
                .ForMember(dest => dest.OrderType, opt => {
                    opt.PreCondition(src => !string.IsNullOrEmpty(src.OrderBy));
                    opt.MapFrom<OrderyByTypeQueryResolver>();
                });
        }
    }
}

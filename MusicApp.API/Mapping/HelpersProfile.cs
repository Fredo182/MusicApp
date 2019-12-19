using System;
using System.Collections.Generic;
using AutoMapper;
using MusicApp.API.Contracts.V1.Requests.Queries;
using MusicApp.API.Contracts.V1.Requests.Queries.Shared;
using MusicApp.API.Helpers;
using MusicApp.Services.Models.Queries;
using MusicApp.Services.Models.Queries.Shared;

namespace MusicApp.API.Mapping
{
    public class HelpersProfile : Profile
    {
        public HelpersProfile()
        {
            CreateMap<PaginationQuery, PaginationModel>()
                .ForMember(dest => dest.Valid, opt => opt.MapFrom( s => (s.PageNumber != null && s.PageSize != null)));

            CreateMap<ArtistFilterQuery, ArtistFilterModel>();
            CreateMap<OrderByQuery, IEnumerable<ArtistOrderByModel>>().ConstructUsing(x => OrderByQueryParser<ArtistOrderByModel>.Parse(x.OrderBy));
        }
    }
}

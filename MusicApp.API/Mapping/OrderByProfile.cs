using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MusicApp.API.Contracts.V1.Requests.Queries.Shared;
using MusicApp.API.Contracts.V1.Responses.ArtistsResponses;
using MusicApp.Services.Models.Queries;
using MusicApp.Services.Models.Queries.Shared;

namespace MusicApp.API.Mapping
{
    public class OrderByProfile : Profile
    {
        //public class ArtistOrderByModelResolver : IValueResolver<OrderByQuery, IEnumerable<ArtistOrderByModel>, IEnumerable<ArtistOrderByModel>>
        //{
        //    public IEnumerable<ArtistOrderByModel> Resolve(OrderByQuery source, IEnumerable<ArtistOrderByModel> destination, IEnumerable<ArtistOrderByModel> member, ResolutionContext context)
        //    {
        //        List<ArtistOrderByModel> orderByList = new List<ArtistOrderByModel>();

        //        List<string> orderByFields = source.OrderBy.Split(',').Select(p => p.Trim()).ToList();
        //        foreach (var orderByField in orderByFields)
        //        {
        //            var field = "";
        //            var sortType = "asc";

        //            if (((orderByField[0] == '+') || (orderByField[0] == '-')) && orderByField.Length > 1)
        //            {
        //                field = orderByField.Substring(1);
        //                if (orderByField[0] == '-')
        //                    sortType = "desc";
        //            }
        //            else
        //                field = orderByField;

        //            ArtistOrderByModel artistOrder = new ArtistOrderByModel();
        //            var property = artistOrder.GetType().GetProperty(field);
        //            var propertySortType = artistOrder.GetType().GetProperty(field + "SortType");
        //            if ( property != null && propertySortType != null)
        //            {
        //                property.SetValue(artistOrder, true);
        //                propertySortType.SetValue(artistOrder, sortType);

        //                orderByList.Add(artistOrder);
        //            }
        //        }

        //        return orderByList;
        //    }
        //}

        public class OrderByQueryToArtistOrderByModelConverter : ITypeConverter<OrderByQuery, IEnumerable<ArtistOrderByModel>>
        {
            public IEnumerable<ArtistOrderByModel> Convert(OrderByQuery source, IEnumerable<ArtistOrderByModel> destination, ResolutionContext context)
            {
                List<ArtistOrderByModel> orderByList = new List<ArtistOrderByModel>();

                if (!string.IsNullOrEmpty(source.OrderBy))
                {
                    List<string> orderByFields = source.OrderBy.Split(',').Select(p => p.Trim()).ToList();
                    foreach (var orderByField in orderByFields)
                    {
                        var field = "";
                        var sortType = "asc";

                        if (!string.IsNullOrWhiteSpace(orderByField))
                        {
                            if (orderByField.Length > 1 && ((orderByField[0] == '+') || (orderByField[0] == '-')))
                            {
                                field = orderByField.Substring(1);
                                if (orderByField[0] == '-')
                                    sortType = "desc";
                            }
                            else
                                field = orderByField;

                            ArtistOrderByModel artistOrder = new ArtistOrderByModel();
                            var property = artistOrder.GetType().GetProperty(field);
                            var propertySortType = artistOrder.GetType().GetProperty("SortType");
                            if (property != null && propertySortType != null)
                            {
                                property.SetValue(artistOrder, true);
                                propertySortType.SetValue(artistOrder, sortType);

                                orderByList.Add(artistOrder);
                            }
                        }
                    }
                }

                return orderByList;
            }
        }

        public OrderByProfile()
        {
            CreateMap<OrderByQuery, IEnumerable<ArtistOrderByModel>>().ConvertUsing<OrderByQueryToArtistOrderByModelConverter>();
            
        }

        
    }
}

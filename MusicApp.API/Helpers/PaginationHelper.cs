using System;
using System.Collections.Generic;
using System.Linq;
using MusicApp.API.Contracts.V1.Requests.Queries;
using MusicApp.API.Contracts.V1.Responses.Shared;
using MusicApp.Services.Models.Shared;

namespace MusicApp.API.Helpers
{
    public class PaginationHelper
    {
        public static PagedResponse<T> CreatePaginatedResponse<T>(PaginationFilter pagination, List<T> response)
        {
            return new PagedResponse<T>
            {
                Data = response,
                PageNumber = pagination.PageNumber >= 1 ? pagination.PageNumber : (int?)null,
                PageSize = pagination.PageSize >= 1 ? pagination.PageSize : (int?)null
            };
        }
    }
}

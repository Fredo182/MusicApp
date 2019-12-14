using System;
namespace MusicApp.API.Contracts.V1.Requests.Queries.Shared
{
    public class PaginationQuery
    {
        public int? PageNumber { get; set; }

        public int? PageSize { get; set; }
    }
}

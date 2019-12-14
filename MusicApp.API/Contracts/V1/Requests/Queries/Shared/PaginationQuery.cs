using System;
namespace MusicApp.API.Contracts.V1.Requests.Queries.Shared
{
    public class PaginationQuery
    {
        public PaginationQuery()
        {
        }

        public PaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            // Can limit the size of the page size here
            // if(pageSize > 1000)
            //     PageSize = 1000;
            PageSize = pageSize;
        }

        public int? PageNumber { get; set; }

        public int? PageSize { get; set; }
    }
}

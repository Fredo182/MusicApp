using System;
using MusicApp.Data.Domain.Queries.Shared;

namespace MusicApp.Data.Domain.Shared
{
    public class PaginationState
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public int Total { get; set; }

        public int FirstRowOnPage { get { return (PageNumber - 1) * PageSize + 1; } }

        public int LastRowOnPage { get { return Math.Min(PageNumber * PageSize, Total); } }

        public PaginationState()
        { }

        public PaginationState(Pagination pagination)
        {
            PageNumber = pagination.PageNumber;
            PageSize = pagination.PageSize;
        }
    }
}

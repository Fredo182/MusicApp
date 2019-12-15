using System;
using System.Collections.Generic;

namespace MusicApp.Data.Domain.Shared
{
    public class PaginationState
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int Total { get; set; }

        public int FirstRowOnPage
        {
            get { return (PageNumber - 1) * PageSize + 1; }
        }

        public int LastRowOnPage
        {
            get { return Math.Min(PageNumber * PageSize, Total); }
        }
    }

    public class PagedResult<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity> Result { get; set; }

        public PaginationState PageState { get; set; }

        public PagedResult()
        {
            Result = new List<TEntity>();
            PageState = new PaginationState();
        }
    }
}

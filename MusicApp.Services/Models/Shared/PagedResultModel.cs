using System;
using System.Collections.Generic;
using MusicApp.Data.Domain.Shared;

namespace MusicApp.Services.Models.Shared
{
    public class PaginationStateModel
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public int Total { get; set; }

        public int FirstRowOnPage { get; set; }

        public int LastRowOnPage { get; set; }
    }

    public class PagedResultModel<T> where T : class
    {
        public PagedResultModel(PaginationState pageState, IEnumerable<T> result)
        {
            PageState = new PaginationStateModel
            {
                PageNumber = pageState.PageNumber,
                PageSize = pageState.PageSize,
                TotalPages = pageState.TotalPages,
                Total = pageState.Total,
                FirstRowOnPage = pageState.FirstRowOnPage,
                LastRowOnPage = pageState.LastRowOnPage
            };
            Result = result;
        }
        
        public IEnumerable<T> Result { get; set; }

        public PaginationStateModel PageState { get; set; }
    }
}

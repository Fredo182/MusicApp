using System;
using System.Collections.Generic;
using MusicApp.Services.Models.Shared;

namespace MusicApp.API.Contracts.V1.Responses.Shared
{
    public class PagedResponse<T>
    {
        public PagedResponse(){}

        public PagedResponse(IEnumerable<T> data)
        {
            Data = data;
        }

        public PagedResponse(IEnumerable<T> data, PaginationStateModel pageState)
        {
            Data = data;
            PageNumber = pageState.PageNumber;
            PageSize = pageState.PageSize;
            TotalPages = pageState.TotalPages;
            Total = pageState.Total;
            FirstRowOnPage = pageState.FirstRowOnPage;
            LastRowOnPage = pageState.LastRowOnPage;
        }

        public IEnumerable<T> Data { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public int Total { get; set; }

        public int FirstRowOnPage { get; set; }

        public int LastRowOnPage { get; set; }

    }
}





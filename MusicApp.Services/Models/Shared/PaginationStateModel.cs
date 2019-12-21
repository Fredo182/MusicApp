using System;
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
}

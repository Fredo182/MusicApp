using System;
namespace MusicApp.Services.Models.Shared
{
    public class PaginationFilter
    {
        //TODO: Probably rename this to PaginationFilterModel
        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }
}

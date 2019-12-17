using System;
namespace MusicApp.Services.Models.Queries.Shared
{
    public class PaginationModel
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public bool Valid { get; set; }
    }
}

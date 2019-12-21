using System;
using System.Collections.Generic;
using MusicApp.Data.Domain.Queries.Shared;

namespace MusicApp.Data.Domain.Shared
{
    public class PaginationResult<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity> Result { get; set; }

        public PaginationState PageState { get; set; }

        public PaginationResult()
        {
            Result = new List<TEntity>();
            PageState = new PaginationState();
        }

        public PaginationResult(Pagination pagination)
        {
            Result = new List<TEntity>();
            PageState = new PaginationState(pagination);
        }
    }
}

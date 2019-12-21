using System;
using System.Collections.Generic;
using MusicApp.Data.Domain.Shared;

namespace MusicApp.Services.Models.Shared
{
    public class PaginationResultModel<T> where T : class
    {
        public IEnumerable<T> Result { get; set; }

        public PaginationStateModel PageState { get; set; }

        public PaginationResultModel()
        {
            Result = new List<T>();
            PageState = new PaginationStateModel();
        }

        // This needs to move to automapper
        public PaginationResultModel(PaginationStateModel pageState, IEnumerable<T> result)
        {
            PageState = pageState;
            Result = result;
        }
    }
}

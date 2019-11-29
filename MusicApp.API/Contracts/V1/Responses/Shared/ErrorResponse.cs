using System;
using System.Collections.Generic;

namespace MusicApp.API.Contracts.V1.Responses.Shared
{
    public class ErrorResponse
    {
        public ErrorResponse(){}

        public ErrorResponse(ErrorModel error)
        {
            Errors.Add(error);
        }

        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }
}

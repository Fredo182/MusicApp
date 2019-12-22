using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicApp.API.Contracts.V1.Responses.Shared
{
    public class ErrorResponse
    {
        public ErrorResponse(){}

        public ErrorResponse(ErrorModel error)
        {
            Errors.Add(error);
        }

        public ErrorResponse(string message)
        {
            Errors.Add(new ErrorModel { Message = message });
        }

        public ErrorResponse(string field, string message)
        {
            Errors.Add(new ErrorModel { FieldName = field, Message = message });
        }

        public ErrorResponse(string field, string message, IEnumerable<string> dynamicMessage)
        {
            foreach (var m in dynamicMessage)
                message += Environment.NewLine + m;

            ErrorModel error = new ErrorModel
            {
                FieldName = field,
                Message = message
            };

            Errors.Add(error);
        }

        public ErrorResponse(string message, IEnumerable<string> dynamicMessage)
        {
            if (dynamicMessage.Count() > 0)
                message += Environment.NewLine;

            foreach (var m in dynamicMessage)
                message += Environment.NewLine + m;

            ErrorModel error = new ErrorModel
            {
                Message = message
            };

            Errors.Add(error);
        }

        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }
}

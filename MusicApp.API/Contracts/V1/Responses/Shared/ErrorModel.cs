using System;
namespace MusicApp.API.Contracts.V1.Responses.Shared
{
    public class ErrorModel
    {
        public string FieldName { get; set; }

        public string Message { get; set; }
    }
}

using System;
namespace MusicApp.API.Contracts.V1.Responses.Shared
{
    public class Response<T>
    {
        public Response(){}

        public Response(T response)
        {
            Data = response;
        }

        public T Data { get; set; }

    }
}

using System;
using System.Collections.Generic;

namespace MusicApp.Services.Services.Shared
{
    public class ServiceResponse<T>
    {
        public ServiceResponse(){
        }

        public ServiceResponse(T response)
        {
            Success = true;
            Data = response;
        }

        public ServiceResponse(string error)
        {
            Success = false;
            Errors = new List<string>() { error };
        }

        public ServiceResponse(IEnumerable<string> errors)
        {
            Success = false;
            Errors = errors;
        }

        public bool Success { get; set; }

        public T Data { get; set; }

        public IEnumerable<string> Errors { get; set; } = new List<string>();

    }

    public class ServiceResponse
    {
        public ServiceResponse()
        {
            Success = true;
        }

        public ServiceResponse(string error)
        {
            Success = false;
            Errors = new List<string>() { error };
        }

        public ServiceResponse(IEnumerable<string> errors)
        {
            Success = false;
            Errors = errors;
        }

        public bool Success { get; set; }

        public IEnumerable<string> Errors { get; set; } = new List<string>();

    }
}

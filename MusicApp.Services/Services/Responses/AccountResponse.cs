using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace MusicApp.Services.Services.Responses
{
    public class AccountResponse
    {
        public bool Success { get; set; } = false;

        // Custom Errors
        public bool SendConfirmEmailFailed { get; set; } = false;
        public bool SendResetPasswordFailed { get; set; } = false;
        public bool UserNotFound { get; set; } = false;
        public bool EmailNotConfirmed { get; set; } = false;

        // Identity Errors
        public IEnumerable<IdentityError> Errors { get; set; } = new List<IdentityError>();
    }

    public class AccountResponse<TData>
    {
        public AccountResponse() { }
        public AccountResponse(TData data)
        {
            Success = true;
            Data = data;
        }
        public bool Success { get; set; } = false;

        public TData Data { get; set; }

        // Custom Errors
        public bool SendConfirmEmailFailed { get; set; } = false;
        public bool SendResetPasswordFailed { get; set; } = false;
        public bool UserNotFound { get; set; } = false;
        public bool EmailNotConfirmed { get; set; } = false;

        // Identity Errors
        public IEnumerable<IdentityError> Errors { get; set; } = new List<IdentityError>();
    }


}

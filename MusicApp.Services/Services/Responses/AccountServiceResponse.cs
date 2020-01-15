using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace MusicApp.Services.Services.Responses
{
    public class AccountServiceResponse
    {
        public AccountServiceResponse() { }

        public AccountServiceResponse(string accessToken, string refreshToken)
        {
            Success = true;
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }

        public bool Success { get; set; } = false;

        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        // Custom Errors
        public bool SendConfirmEmailFailed { get; set; } = false;
        public bool SendResetPasswordFailed { get; set; } = false;
        public bool UserNotFound { get; set; } = false;
        public bool EmailNotConfirmed { get; set; } = false;

        // Identity Errors
        public IEnumerable<IdentityError> Errors { get; set; } = new List<IdentityError>();
    }

    


}

﻿using System;
namespace MusicApp.API.Contracts.V1.Responses.AccountsResponses
{
    public class AccountLoginResponse
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }
    }
}

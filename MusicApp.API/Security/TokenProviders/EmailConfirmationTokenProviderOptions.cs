using System;
using Microsoft.AspNetCore.Identity;

namespace MusicApp.API.Security.TokenProviders
{
    public class EmailConfirmationTokenProviderOptions : DataProtectionTokenProviderOptions
    {
        public EmailConfirmationTokenProviderOptions()
        {
        }
    }
}

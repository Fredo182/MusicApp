using System;
namespace MusicApp.API.Contracts.V1.Requests.AccountsRequests
{
    public class AccountRefreshRequest
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }
    }
}

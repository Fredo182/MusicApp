using System;
namespace MusicApp.API.Contracts.V1.Requests.AccountsRequests
{
    public class AccountLoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

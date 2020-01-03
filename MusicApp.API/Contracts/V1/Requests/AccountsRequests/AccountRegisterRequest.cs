using System;
namespace MusicApp.API.Contracts.V1.Requests.AccountsRequests
{
    public class AccountRegisterRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

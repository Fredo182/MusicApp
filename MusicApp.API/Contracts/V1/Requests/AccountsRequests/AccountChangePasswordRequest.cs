using System;
namespace MusicApp.API.Contracts.V1.Requests.AccountsRequests
{
    public class AccountChangePasswordRequest
    {
        public string Email { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}

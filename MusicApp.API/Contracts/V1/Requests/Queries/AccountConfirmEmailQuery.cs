using System;
namespace MusicApp.API.Contracts.V1.Requests.Queries
{
    public class AccountConfirmEmailQuery
    {
        public int UserId { get; set; }

        public string Token { get; set; }
    }
}

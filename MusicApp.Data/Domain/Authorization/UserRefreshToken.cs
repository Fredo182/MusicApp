using System;
using MusicApp.Data.Domain.Authorization.Shared;

namespace MusicApp.Data.Domain.Authorization
{
    public class UserRefreshToken : UserRefreshTokenBaseDomain
    {
        public int UserRefreshTokenId { get; set; }

        public string RefreshToken { get; set; }

        public string JwtId { get; set; }

        public DateTimeOffset ExpiryDate { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}

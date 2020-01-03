using System;
using MusicApp.Data.Domain.Authorization.Shared;

namespace MusicApp.Data.Domain.Authorization
{
    public class UserClaim : UserClaimBaseDomain
    {
        public User User { get; set; }
    }
}

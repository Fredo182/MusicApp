using System;
using MusicApp.Data.Domain.Authorization.Shared;

namespace MusicApp.Data.Domain.Authorization
{
    public class UserToken : UserTokenBaseDomain
    {
        public User User { get; set; }
    }
}

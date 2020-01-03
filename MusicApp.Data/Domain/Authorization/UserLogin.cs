using System;
using MusicApp.Data.Domain.Authorization.Shared;

namespace MusicApp.Data.Domain.Authorization
{
    public class UserLogin : UserLoginBaseDomain
    {
        public User User { get; set; }
    }
}

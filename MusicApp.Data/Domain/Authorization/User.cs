using System;
using System.Collections.Generic;
using MusicApp.Data.Domain.Authorization.Shared;

namespace MusicApp.Data.Domain.Authorization
{
    public class User : UserBaseDomain
    {
        public User()
        {
            Claims = new List<UserClaim>();
            Logins = new List<UserLogin>();
            Tokens = new List<UserToken>();
            UserRoles = new List<UserRole>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<UserClaim> Claims { get; private set; }

        public ICollection<UserLogin> Logins { get; private set; }

        public ICollection<UserToken> Tokens { get; private set; }

        public ICollection<UserRole> UserRoles { get; private set; }

    }
}

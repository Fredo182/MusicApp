using System;
using System.Collections.Generic;
using MusicApp.Data.Domain.Authorization.Shared;

namespace MusicApp.Data.Domain.Authorization
{
    public class Role : RoleBaseDomain
    {
        public Role()
        {
            UserRoles = new List<UserRole>();
            RoleClaims = new List<RoleClaim>();
        }

        public string Description { get; set; }

        public ICollection<UserRole> UserRoles { get; private set; }

        public ICollection<RoleClaim> RoleClaims { get; private set; }
    }
}

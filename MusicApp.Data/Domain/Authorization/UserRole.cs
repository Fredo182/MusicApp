using System;
using MusicApp.Data.Domain.Authorization.Shared;

namespace MusicApp.Data.Domain.Authorization
{
    public class UserRole : UserRoleBaseDomain
    {
        public User User { get; set; }

        public Role Role { get; set; }
    }
}

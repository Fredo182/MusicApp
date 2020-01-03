using System;
using MusicApp.Data.Domain.Authorization.Shared;

namespace MusicApp.Data.Domain.Authorization
{
    public class RoleClaim : RoleClaimBaseDomain
    {
        public Role Role { get; set; }
    }
}

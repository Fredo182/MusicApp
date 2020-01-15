using System;
using Microsoft.AspNetCore.Identity;

namespace MusicApp.Data.Domain.Authorization.Shared
{
    public class RoleBaseDomain : IdentityRole<int>
    {
        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTimeOffset? ModifiedDateTime { get; set; }

        public DateTimeOffset? CreatedDateTime { get; set; }
    }

    public class UserBaseDomain : IdentityUser<int>
    {
        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTimeOffset? ModifiedDateTime { get; set; }

        public DateTimeOffset? CreatedDateTime { get; set; }
    }

    public class UserRoleBaseDomain : IdentityUserRole<int>
    {
        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public byte[] ConcurrencyStamp { get; set; }

        public DateTimeOffset? ModifiedDateTime { get; set; }

        public DateTimeOffset? CreatedDateTime { get; set; }
    }

    public class UserRefreshTokenBaseDomain
    {
        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public byte[] ConcurrencyStamp { get; set; }

        public DateTimeOffset? ModifiedDateTime { get; set; }

        public DateTimeOffset? CreatedDateTime { get; set; }
    }

    public class RoleClaimBaseDomain : IdentityRoleClaim<int> { }
    public class UserClaimBaseDomain : IdentityUserClaim<int> { }
    public class UserLoginBaseDomain : IdentityUserLogin<int> { }
    public class UserTokenBaseDomain : IdentityUserToken<int> { }

}

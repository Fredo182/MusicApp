using System;
using Microsoft.AspNetCore.Identity;

namespace MusicApp.Services.Models.Authorization.Shared
{
    public class RoleBaseModel : IdentityRole<int>
    {
        public bool? IsActive { get; set; } = true;

        public bool? IsDeleted { get; set; } = false;

        public DateTimeOffset? ModifiedDateTime { get; set; }

        public DateTimeOffset? CreatedDateTime { get; set; }
    }

    public class UserBaseModel : IdentityUser<int>
    {
        public bool? IsActive { get; set; } = true;

        public bool? IsDeleted { get; set; } = false;

        public DateTimeOffset? ModifiedDateTime { get; set; }

        public DateTimeOffset? CreatedDateTime { get; set; }
    }

    public class UserRoleBaseModel : IdentityUserRole<int>
    {
        public bool? IsActive { get; set; } = true;

        public bool? IsDeleted { get; set; } = false;

        public byte[] ConcurrencyStamp { get; set; }

        public DateTimeOffset? ModifiedDateTime { get; set; }

        public DateTimeOffset? CreatedDateTime { get; set; }
    }

    public class RoleClaimBaseModel : IdentityRoleClaim<int> { }
    public class UserClaimBaseModel : IdentityUserClaim<int> { }
    public class UserLoginBaseModel : IdentityUserLogin<int> { }
    public class UserTokenBaseModel : IdentityUserToken<int> { }
}

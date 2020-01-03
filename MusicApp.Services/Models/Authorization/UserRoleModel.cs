using System;
using MusicApp.Services.Models.Authorization.Shared;

namespace MusicApp.Services.Models.Authorization
{
    public class UserRoleModel : UserRoleBaseModel
    {
        public UserModel User { get; set; }

        public RoleModel Role { get; set; }
    }
}

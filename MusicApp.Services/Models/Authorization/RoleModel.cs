using System;
using System.Collections.Generic;
using MusicApp.Services.Models.Authorization.Shared;

namespace MusicApp.Services.Models.Authorization
{
    public class RoleModel : RoleBaseModel
    {
        public RoleModel()
        {
            UserRoles = new List<UserRoleModel>();
            RoleClaims = new List<RoleClaimModel>();
        }

        public string Description { get; set; }

        public ICollection<UserRoleModel> UserRoles { get; private set; }

        public ICollection<RoleClaimModel> RoleClaims { get; private set; }
    }
}

using System;
using MusicApp.Services.Models.Authorization.Shared;

namespace MusicApp.Services.Models.Authorization
{
    public class RoleClaimModel : RoleClaimBaseModel
    {
        public RoleModel Role { get; set; }
    }
}

using System;
using MusicApp.Services.Models.Authorization.Shared;

namespace MusicApp.Services.Models.Authorization
{
    public class UserClaimModel : UserClaimBaseModel
    {
        public UserModel User { get; set; }
    }
}

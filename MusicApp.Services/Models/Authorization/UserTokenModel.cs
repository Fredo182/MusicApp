using System;
using MusicApp.Services.Models.Authorization.Shared;

namespace MusicApp.Services.Models.Authorization
{
    public class UserTokenModel : UserTokenBaseModel
    {
        public UserModel User { get; set; }
    }
}

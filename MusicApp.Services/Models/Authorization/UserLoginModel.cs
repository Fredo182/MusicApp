using System;
using MusicApp.Services.Models.Authorization.Shared;

namespace MusicApp.Services.Models.Authorization
{
    public class UserLoginModel : UserLoginBaseModel
    {
        public UserModel User { get; set; }
    }
}

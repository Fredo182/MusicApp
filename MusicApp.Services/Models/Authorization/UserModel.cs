using System;
using System.Collections.Generic;
using MusicApp.Services.Models.Authorization.Shared;

namespace MusicApp.Services.Models.Authorization
{
    public class UserModel : UserBaseModel
    {
        public UserModel()
        {
            Claims = new List<UserClaimModel>();
            Logins = new List<UserLoginModel>();
            Tokens = new List<UserTokenModel>();
            UserRoles = new List<UserRoleModel>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<UserClaimModel> Claims { get; private set; }

        public ICollection<UserLoginModel> Logins { get; private set; }

        public ICollection<UserTokenModel> Tokens { get; private set; }

        public ICollection<UserRoleModel> UserRoles { get; private set; }

    }
}

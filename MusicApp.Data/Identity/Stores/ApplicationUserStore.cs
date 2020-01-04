using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MusicApp.Data.Domain.Authorization;

namespace MusicApp.Data.Identity.Stores
{
    public class ApplicationUserStore : UserStore<User, Role, MusicAppDbContext, int, UserClaim, UserRole, UserLogin, UserToken, RoleClaim>
    {
        public ApplicationUserStore(MusicAppDbContext context) : base(context)
        {
            AutoSaveChanges = false;
        }
    }
}

using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MusicApp.Data.Domain.Authorization;

namespace MusicApp.Data.Identity.Stores
{
    public class ApplicationRoleStore : RoleStore<Role, MusicAppDbContext, int, UserRole, RoleClaim>
    {
        public ApplicationRoleStore(MusicAppDbContext context) : base(context)
        {
            AutoSaveChanges = false;
        }
    }
}

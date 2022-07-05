using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Persistance;
using Microsoft.AspNetCore.Identity;
using Blog.Domain.Users;

namespace Blog.Persistance.Roles
{
    public static class DatabaseSeed
    {
        public static async Task SeedRolesToAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Blog.Common.Roles.Roles.Admin));
            await roleManager.CreateAsync(new IdentityRole(Blog.Common.Roles.Roles.NormalUser));
            await roleManager.CreateAsync(new IdentityRole(Blog.Common.Roles.Roles.SpecialUser));
        }
    }
}

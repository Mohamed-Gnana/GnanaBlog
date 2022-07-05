using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Blog.Common.Roles;
using Blog.Domain.Users;

namespace Blog.Presentation.Controllers
{
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;

        public RolesController(
            RoleManager<IdentityRole> roleManager,
            UserManager<User> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            if (!(await roleManager.RoleExistsAsync(Roles.Admin)))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
                await roleManager.CreateAsync(new IdentityRole(Roles.NormalUser));
            }

            User user = await userManager.FindByEmailAsync("mohamedgnana@gnana.com");

            if (!user.EmailConfirmed)
            {
                string token = await userManager
                    .GenerateEmailConfirmationTokenAsync(user);

                IdentityResult result = await userManager
                    .ConfirmEmailAsync(user, token);

                if (result.Succeeded)
                {
                    Console.WriteLine($"User {user.UserName} email confirmed successfully...");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        Console.WriteLine(error.Description);
                    }
                }
            }

            if (!(await userManager.IsInRoleAsync(user, Roles.Admin)))
            {
                IdentityResult result = await userManager
                    .AddToRoleAsync(user, Roles.Admin);

                if (result.Succeeded)
                {
                    Console.WriteLine($"User {user.UserName} added to {Roles.Admin} successfully");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        Console.WriteLine(error.Description);
                    }
                }
            }

            return Redirect("/");
        }
    }
}

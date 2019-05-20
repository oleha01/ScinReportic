using Microsoft.AspNetCore.Identity;
using ScinReport.Models;
using System.Threading.Tasks;

namespace RolesInitializerApp
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {ScinReport
            string adminEmail = "admin@gmail.com";
            string password = "_Aa123456";
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("teacher") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("teacher"));
            }
            if (await roleManager.FindByNameAsync("manager") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("manager"));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                User admin = new User { Email = adminEmail, UserName = adminEmail };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
    }
}
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace ConferenceManager.Data
{
    public class UserModel
    {
        public string Username { get; set; }
        public string Role { get; set; }
    }

    public static class SeedIdentityData
    {
        //These are SeedData for users, you need a foreach to go through them
        private static readonly List<UserModel> SeedUsers = new List<UserModel>
        {
           new UserModel {Username = "mary", Role = "Author" },
           new UserModel {Username = "john", Role = "Author"},
           new UserModel {Username = "thabo", Role = "Author"},
           new UserModel {Username = "admin", Role = "Admin"}
        };

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            AppIdentityDbContext context = app.ApplicationServices
               .CreateScope().ServiceProvider
               .GetRequiredService<AppIdentityDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            UserManager<IdentityUser> userManager = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<UserManager<IdentityUser>>();

            RoleManager<IdentityRole> roleManager = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<RoleManager<IdentityRole>>(); 
            
            //Users are created here using foreach and the seedusers
            foreach (var seedUser in SeedUsers)
            {
                if (await roleManager.FindByNameAsync(seedUser.Role) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(seedUser.Role));
                }

                IdentityUser user = new IdentityUser
                {
                    UserName = seedUser.Username,
                    Email = seedUser.Username + "@ufs.ac.za"
                };

                IdentityResult result = await userManager.CreateAsync(user, seedUser.Username + "@1");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, seedUser.Role);
                }
            }
        }
    }
}

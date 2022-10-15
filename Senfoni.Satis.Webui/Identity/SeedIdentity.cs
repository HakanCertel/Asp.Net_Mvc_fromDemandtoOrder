using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senfoni.Satis.Webui.Identity
{
    public class SeedIdentity
    {
        public static async Task Seed(UserManager<User> userManager,RoleManager<IdentityRole> roleManager,IConfiguration configuration)
        {
            var userName = configuration["Data:AdminUser:username"];
            var email = configuration["Data:AdminUser:email"];
            var password = configuration["Data:AdminUser:password"];
            var role = configuration["Data:AdminUser:role"];

            if(await userManager.FindByNameAsync(userName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(role));

                var user = new User
                {
                    UserName=userName,
                    Email=email,
                    FirstName="admin",
                    LastName="admin",
                    EmailConfirmed=true,
                };

                var result = await userManager.CreateAsync(user,password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }
    }
}

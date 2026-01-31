using HotelManager.Data;
using HotelManager.Models;
using Microsoft.AspNetCore.Identity;

namespace HotelManager.Services
{
    public class SeedService
    {
        public static async Task SeedDatabase (IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Users>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<SeedService>>();

            try
            //Ensure the database is ready
            {
                logger.LogInformation("Ensuring the Database is created.");
                await context.Database.EnsureCreatedAsync();

                //add roles 
                logger.LogInformation("Seeding Roles.");
                await AddRoleAsync(roleManager, "Admin");
                await AddRoleAsync(roleManager, "User");

                //add default admin user
                logger.LogInformation("Seeding Default Admin User.");
                var adminEmail = "admin@greatneshotel.com";
                if (await userManager.FindByEmailAsync(adminEmail) == null)
                {
                    var adminUser = new Users
                    {
                        FullName = "Greatness Hotel",
                        UserName = adminEmail,
                        NormalizedUserName = adminEmail.ToUpper(),
                        Email = adminEmail,
                        NormalizedEmail = adminEmail.ToUpper(),
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString(),

                    };
                
                    var result = await userManager.CreateAsync(adminUser, "Admin@123");
                    if (result.Succeeded)
                    {
                        logger.LogInformation("Assigning Admin Role TO The Admin User.");
                        await userManager.AddToRoleAsync(adminUser, "Admin");

                    }
                    else
                    {
                        logger.LogError("Failed to create admin user: {Errors}", string.Join(",", result.Errors.Select(e => e.Description)));
                    }
                }

            }
            catch(Exception ex) {

                logger.LogError(ex, "An error occured while seeding the database");
            }

        }

        private static async Task AddRoleAsync(RoleManager<IdentityRole> roleManager, string roleName)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                var result = await roleManager.CreateAsync(new IdentityRole(roleName));
                if (!result.Succeeded)
                {
                    throw new Exception($"Failed to create role' {roleName}': {string.Join(",", result.Errors.Select(e => e.Description))}");
                }
            }
        }
    }
}

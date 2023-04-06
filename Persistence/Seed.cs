using AuthorizationAndAuthentication.Core;
using AuthorizationAndAuthentication.Entities.Models;
using AuthorizationAndAuthentication.Entities.Resources;

namespace AuthorizationAndAuthentication.Persistence;


public class Seed
{
    public static void SeedRolesAndAdmin(AuthDbContext context, IUserManager userManager, IRoleManger roleManager)
    {
        if (!roleManager.GetRoles().Any())
        {
            roleManager.Add(new Role { Name = Policies.Admin });
            roleManager.Add(new Role { Name = Policies.Moderator });
            roleManager.Add(new Role { Name = Policies.Client });
        }
        if (!userManager.GetUsers().Any())
        {
            var user = new User()
            {
                Email = "admin@admin.com"
            };
            userManager.Add(user, "Admin-1234567890");
            userManager.AddRoleToUser(user, Policies.Admin);
            userManager.AddRoleToUser(user, Policies.Moderator);
            userManager.AddRoleToUser(user, Policies.Client);

        }
        if (context.ChangeTracker.HasChanges())
        {
            context.SaveChangesAsync();
        }
    }

}
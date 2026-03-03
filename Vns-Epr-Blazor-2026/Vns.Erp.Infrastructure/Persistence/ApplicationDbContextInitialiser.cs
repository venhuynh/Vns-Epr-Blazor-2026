using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Vns.Erp.Domain.Identity;

namespace Vns.Erp.Infrastructure.Persistence;

public class ApplicationDbContextInitialiser(
    ILogger<ApplicationDbContextInitialiser> logger,
    ApplicationDbContext context,
    UserManager<ApplicationUser> userManager,
    RoleManager<ApplicationRole> roleManager)
{
    public async Task InitialiseAsync()
    {
        try
        {
            if (context.Database.IsNpgsql())
            {
                await context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default roles
        var superAdminRole = new ApplicationRole("SuperAdmin") { Description = "Full system access" };
        var adminRole = new ApplicationRole("Admin") { Description = "General administrative access" };
        var warehouseManagerRole = new ApplicationRole("WarehouseManager") { Description = "Inventory and warehouse operations" };
        var salesManagerRole = new ApplicationRole("SalesManager") { Description = "Sales and customer operations" };
        var accountantRole = new ApplicationRole("Accountant") { Description = "Financial and accounting operations" };

        var roles = new List<ApplicationRole>
        {
            superAdminRole,
            adminRole,
            warehouseManagerRole,
            salesManagerRole,
            accountantRole
        };

        foreach (var role in roles)
        {
            if (roleManager.Roles.All(r => r.Name != role.Name))
            {
                await roleManager.CreateAsync(role);
            }
        }

        // Default users
        var administrator = new ApplicationUser 
        { 
            UserName = "admin@vns.com.vn", 
            Email = "admin@vns.com.vn",
            FirstName = "System",
            LastName = "Administrator",
            DisplayName = "Administrator",
            EmailConfirmed = true
        };

        if (userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await userManager.CreateAsync(administrator, "Admin@2026!");
            if (!string.IsNullOrWhiteSpace(superAdminRole.Name))
            {
                await userManager.AddToRolesAsync(administrator, new[] { superAdminRole.Name });
            }
        }
    }
}

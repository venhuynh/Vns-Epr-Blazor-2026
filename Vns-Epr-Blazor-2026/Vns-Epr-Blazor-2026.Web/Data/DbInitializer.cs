using Microsoft.AspNetCore.Identity;

namespace Vns_Epr_Blazor_2026.Web.Data;

/// <summary>
/// Database initializer — tương tự Updater.cs trong XAF.
/// Tạo roles và users mặc định khi DB rỗng.
/// </summary>
public static class DbInitializer
{
    /// <summary>
    /// Seed roles và admin user — gọi trong Program.cs
    /// Tham khảo: XAF Updater.CreateAdminRole() + CreateDefaultRole()
    /// </summary>
    public static async Task SeedAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        // === TẠO ROLES (ref XAF: Administrators, Default) ===
        string[] roles = [
            "Administrators",   // Full quyền (ref XAF adminRole.IsAdministrative = true)
            "Manager",          // R/W all modules, không quản lý users
            "InventoryStaff",   // R/W Inventory, Read MasterData
            "SalesStaff",       // R/W Partner, Read Product/Inventory
            "Viewer"            // Read-only
        ];

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        // === TẠO ADMIN USER (ref XAF: Updater.cs lines 57-67) ===
        const string adminUserName = "admin@vns.com";
        const string adminPassword = "Admin@2026!";

        var adminUser = await userManager.FindByEmailAsync(adminUserName);
        if (adminUser == null)
        {
            adminUser = new ApplicationUser
            {
                UserName = adminUserName,
                Email = adminUserName,
                FullName = "System Administrator",
                EmailConfirmed = true,
                ChangePasswordOnFirstLogon = true,
                CreatedDate = DateTime.UtcNow
            };

            var result = await userManager.CreateAsync(adminUser, adminPassword);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Administrators");
            }
        }

        // === TẠO DEFAULT USER (ref XAF: Updater.cs lines 46-55) ===
        const string defaultUserName = "user@vns.com";
        const string defaultPassword = "User@2026!";

        var defaultUser = await userManager.FindByEmailAsync(defaultUserName);
        if (defaultUser == null)
        {
            defaultUser = new ApplicationUser
            {
                UserName = defaultUserName,
                Email = defaultUserName,
                FullName = "Default User",
                EmailConfirmed = true,
                ChangePasswordOnFirstLogon = false,
                CreatedDate = DateTime.UtcNow
            };

            var result = await userManager.CreateAsync(defaultUser, defaultPassword);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(defaultUser, "Viewer");
            }
        }
    }
}

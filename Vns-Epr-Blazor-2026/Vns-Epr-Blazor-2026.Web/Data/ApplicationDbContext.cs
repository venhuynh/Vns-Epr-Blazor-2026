using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Vns_Epr_Blazor_2026.Web.Data;

/// <summary>
/// Application DbContext — tương tự Vns_Erp_xaf_2026EFCoreDbContext trong XAF.
/// Kế thừa IdentityDbContext thay vì DbContext thuần.
/// </summary>
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Đổi tên bảng Identity cho gọn (optional, ref XAF table naming)
        builder.Entity<ApplicationUser>(b =>
        {
            b.ToTable("Users");
        });

        builder.Entity<Microsoft.AspNetCore.Identity.IdentityRole>(b =>
        {
            b.ToTable("Roles");
        });

        builder.Entity<Microsoft.AspNetCore.Identity.IdentityUserRole<string>>(b =>
        {
            b.ToTable("UserRoles");
        });

        builder.Entity<Microsoft.AspNetCore.Identity.IdentityUserClaim<string>>(b =>
        {
            b.ToTable("UserClaims");
        });

        builder.Entity<Microsoft.AspNetCore.Identity.IdentityUserLogin<string>>(b =>
        {
            b.ToTable("UserLogins");
        });

        builder.Entity<Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>>(b =>
        {
            b.ToTable("RoleClaims");
        });

        builder.Entity<Microsoft.AspNetCore.Identity.IdentityUserToken<string>>(b =>
        {
            b.ToTable("UserTokens");
        });
    }
}

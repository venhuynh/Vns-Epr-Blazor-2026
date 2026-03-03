using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Domain.Identity;

namespace Vns.Erp.Infrastructure.Persistence;

/// <summary>
/// Application database context with Identity support.
/// Implements IApplicationDbContext from the Application layer.
/// </summary>
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser, ApplicationRole, string>(options), IApplicationDbContext
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Apply all entity configurations from this assembly
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}

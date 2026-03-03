using Microsoft.EntityFrameworkCore;
using Vns.Erp.Domain.Identity;

namespace Vns.Erp.Application.Common.Interfaces;

/// <summary>
/// Abstraction for the application database context.
/// Implemented in Infrastructure layer.
/// </summary>
public interface IApplicationDbContext
{
    DbSet<ApplicationUser> Users { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

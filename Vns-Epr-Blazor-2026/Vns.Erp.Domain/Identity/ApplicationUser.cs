using Microsoft.AspNetCore.Identity;

namespace Vns.Erp.Domain.Identity;

/// <summary>
/// Application user extending ASP.NET Core Identity.
/// Add profile data for application users by adding properties here.
/// </summary>
public class ApplicationUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? DisplayName { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
}

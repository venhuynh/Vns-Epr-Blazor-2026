using Microsoft.AspNetCore.Identity;
using Vns_Epr_Blazor_2026.Web.Data;

namespace Vns_Epr_Blazor_2026.Web.Components.Account;

/// <summary>
/// Helper to get the current user from HttpContext.
/// Ref: DevExpress BlazorDemo.Showcase IdentityUserAccessor
/// </summary>
internal sealed class IdentityUserAccessor(UserManager<ApplicationUser> userManager, IdentityRedirectManager redirectManager)
{
    public async Task<ApplicationUser> GetRequiredUserAsync(HttpContext context)
    {
        var user = await userManager.GetUserAsync(context.User);

        if (user is null)
        {
            redirectManager.RedirectToWithStatus("Account/InvalidUser",
                $"Error: Không thể tải user với ID '{userManager.GetUserId(context.User)}'.", context);
        }

        return user;
    }
}

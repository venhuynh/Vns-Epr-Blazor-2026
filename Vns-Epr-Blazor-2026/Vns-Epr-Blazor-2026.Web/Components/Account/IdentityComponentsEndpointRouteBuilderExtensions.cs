using Microsoft.AspNetCore.Identity;
using Vns_Epr_Blazor_2026.Web.Data;

namespace Microsoft.AspNetCore.Routing;

/// <summary>
/// Maps additional Identity endpoints (Logout, etc.) as minimal APIs.
/// Ref: DevExpress BlazorDemo.Showcase IdentityComponentsEndpointRouteBuilderExtensions
/// </summary>
internal static class IdentityComponentsEndpointRouteBuilderExtensions
{
    public static IEndpointConventionBuilder MapAdditionalIdentityEndpoints(this IEndpointRouteBuilder endpoints)
    {
        ArgumentNullException.ThrowIfNull(endpoints);

        var accountGroup = endpoints.MapGroup("Account");

        accountGroup.MapGet("/Logout", async (
            System.Security.Claims.ClaimsPrincipal user,
            SignInManager<ApplicationUser> signInManager,
            [Microsoft.AspNetCore.Mvc.FromQuery(Name = "ReturnUrl")] string? returnUrl
        ) =>
        {
            await signInManager.SignOutAsync();
            return TypedResults.LocalRedirect($"~/Account/Login");
        });

        return accountGroup;
    }
}

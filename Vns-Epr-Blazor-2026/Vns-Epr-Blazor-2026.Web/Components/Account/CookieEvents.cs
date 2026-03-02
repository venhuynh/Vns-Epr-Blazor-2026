using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.Extensions;

namespace Vns_Epr_Blazor_2026.Web.Components.Account;

/// <summary>
/// Custom cookie events — redirects unauthenticated requests to /Account/Login.
/// Ref: DevExpress BlazorDemo.Showcase CookieEvents
/// </summary>
public class CookieEvents : CookieAuthenticationEvents
{
    public override Task RedirectToLogin(RedirectContext<CookieAuthenticationOptions> context)
    {
        var path = context.Request.Path;
        var redirectUri = UriHelper.BuildRelative(
            context.Request.PathBase,
            "/Account/Login",
            QueryString.Create("ReturnUrl", path.HasValue ? path.Value.TrimStart('/') : string.Empty)
        );
        context.RedirectUri = redirectUri;
        return base.RedirectToLogin(context);
    }
}

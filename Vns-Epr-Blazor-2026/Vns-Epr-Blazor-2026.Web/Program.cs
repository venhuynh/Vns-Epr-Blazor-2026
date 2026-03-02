using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Vns_Epr_Blazor_2026.Shared.Services;
using Vns_Epr_Blazor_2026.Web.Components;
using Vns_Epr_Blazor_2026.Web.Data;
using Vns_Epr_Blazor_2026.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// === DATABASE (ref XAF: UseNpgsql in Startup.cs) ===
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// === IDENTITY (ref XAF: Security.UseIntegratedMode + AddPasswordAuthentication) ===
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    // Password policy
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;

    // Lockout (ref XAF: options.Lockout.Enabled = true)
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

// === COOKIE AUTH (ref XAF: CookieAuthenticationDefaults + LoginPath) ===
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.ExpireTimeSpan = TimeSpan.FromHours(8);
    options.SlidingExpiration = true;
});

// === BLAZOR + DEVEXPRESS ===
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddSingleton<IFormFactor, FormFactor>();
builder.Services.AddDevExpressBlazor();

builder.Services.AddMvc();

var app = builder.Build();

// === SEED DATABASE (ref XAF: Updater.UpdateDatabaseAfterUpdateSchema) ===
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await db.Database.MigrateAsync();
}
await DbInitializer.SeedAsync(app.Services);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();
app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(
        typeof(Vns_Epr_Blazor_2026.Shared._Imports).Assembly,
        typeof(Vns_Epr_Blazor_2026.Web.Client._Imports).Assembly);

app.Run();

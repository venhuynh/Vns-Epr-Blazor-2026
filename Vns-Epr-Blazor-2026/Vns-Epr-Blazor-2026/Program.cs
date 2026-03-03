using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.AI;
using OpenAI;
using Vns_Epr_Blazor_2026.Components;
using Vns_Epr_Blazor_2026.Components.Account;
using Vns.Erp.Application;
using Vns.Erp.Domain.Identity;
using Vns.Erp.Infrastructure;
using Vns.Erp.Infrastructure.ExternalServices.OpenAI;
using Vns.Erp.Infrastructure.Persistence;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDevExpressBlazor(options =>
{
    options.SizeMode = DevExpress.Blazor.SizeMode.Medium;
});
builder.Services.AddMvc();

// Clean Architecture layer DI registration
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var openAiServiceSettings = builder.Configuration.GetSection("OpenAISettings").Get<OpenAIServiceSettings>();
if (openAiServiceSettings != null &&
    !string.IsNullOrEmpty(openAiServiceSettings.Key) &&
    !string.IsNullOrEmpty(openAiServiceSettings.DeploymentName))
{
    var chatClient = new OpenAIClient(openAiServiceSettings.Key)
        .GetChatClient(openAiServiceSettings.DeploymentName)
        .AsIChatClient();

    builder.Services.AddScoped<IChatClient>((provider) => chatClient);
    builder.Services.AddDevExpressAI();
}

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Seed default roles and admin user
    using (var scope = app.Services.CreateScope())
    {
        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();
        await initialiser.InitialiseAsync();
        await initialiser.SeedAsync();
    }
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AllowAnonymous();

app.MapAdditionalIdentityEndpoints();

app.Run();
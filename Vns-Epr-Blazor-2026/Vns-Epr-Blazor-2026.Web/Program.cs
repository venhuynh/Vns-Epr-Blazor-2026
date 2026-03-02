using Vns_Epr_Blazor_2026.Shared.Services;
using Vns_Epr_Blazor_2026.Web.Components;
using Vns_Epr_Blazor_2026.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddSingleton<IFormFactor, FormFactor>();
builder.Services.AddDevExpressBlazor();

builder.Services.AddMvc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
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
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(
        typeof(Vns_Epr_Blazor_2026.Shared._Imports).Assembly,
        typeof(Vns_Epr_Blazor_2026.Web.Client._Imports).Assembly);

app.Run();

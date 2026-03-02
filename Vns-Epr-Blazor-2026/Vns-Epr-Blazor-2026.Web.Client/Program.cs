using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Vns_Epr_Blazor_2026.Shared.Services;
using Vns_Epr_Blazor_2026.Web.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddSingleton<IFormFactor, FormFactor>();
builder.Services.AddDevExpressBlazor();

await builder.Build().RunAsync();

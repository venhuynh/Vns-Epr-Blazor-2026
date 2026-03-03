using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Infrastructure.Persistence;
using Vns.Erp.Infrastructure.Services;

namespace Vns.Erp.Infrastructure;

/// <summary>
/// Registers Infrastructure layer services into the DI container.
/// Called from Program.cs in the Web host project.
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Database — PostgreSQL
        var connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddScoped<IApplicationDbContext>(provider =>
            provider.GetRequiredService<ApplicationDbContext>());

        // Services
        services.AddScoped<ApplicationDbContextInitialiser>();
        services.AddSingleton<IDateTimeService, DateTimeService>();

        return services;
    }
}

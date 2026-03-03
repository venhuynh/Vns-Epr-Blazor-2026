using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Vns.Erp.Application;

/// <summary>
/// Registers Application layer services into the DI container.
/// Called from Program.cs in the Web host project.
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        // MediatR — auto-discovers all IRequestHandler implementations
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

        // AutoMapper — auto-discovers all Profile classes
        services.AddAutoMapper(assembly);

        return services;
    }
}

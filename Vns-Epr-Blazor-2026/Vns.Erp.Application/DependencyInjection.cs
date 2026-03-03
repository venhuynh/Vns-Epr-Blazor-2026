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
        // Register Application layer services here
        // e.g., MediatR handlers, AutoMapper profiles, FluentValidation validators

        return services;
    }
}

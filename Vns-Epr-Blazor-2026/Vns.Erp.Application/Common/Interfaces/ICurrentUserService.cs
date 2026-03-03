namespace Vns.Erp.Application.Common.Interfaces;

/// <summary>
/// Provides the current authenticated user information.
/// </summary>
public interface ICurrentUserService
{
    string? UserId { get; }
    string? UserName { get; }
    bool IsAuthenticated { get; }
}

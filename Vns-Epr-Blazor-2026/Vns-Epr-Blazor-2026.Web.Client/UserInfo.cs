namespace Vns_Epr_Blazor_2026.Web.Client;

/// <summary>
/// Shared DTO for persisting auth state from Server → WebAssembly.
/// </summary>
public class UserInfo
{
    public required string UserId { get; set; }
    public required string Email { get; set; }
    public required string Name { get; set; }
    public required string Role { get; set; }
}

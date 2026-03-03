namespace Vns.Erp.Application.Common.Interfaces;

/// <summary>
/// Date/time service abstraction for testability.
/// </summary>
public interface IDateTimeService
{
    DateTime Now { get; }
    DateTime UtcNow { get; }
}

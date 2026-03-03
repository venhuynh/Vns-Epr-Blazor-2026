using Vns.Erp.Application.Common.Interfaces;

namespace Vns.Erp.Infrastructure.Services;

/// <summary>
/// Default implementation of IDateTimeService.
/// </summary>
public class DateTimeService : IDateTimeService
{
    public DateTime Now => DateTime.Now;
    public DateTime UtcNow => DateTime.UtcNow;
}

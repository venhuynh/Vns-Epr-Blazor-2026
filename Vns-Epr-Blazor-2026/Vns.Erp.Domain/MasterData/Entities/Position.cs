using Vns.Erp.Domain.Common;

namespace Vns.Erp.Domain.MasterData.Entities;

/// <summary>
/// Chức vụ — thuộc Công ty, đánh dấu cấp quản lý.
/// </summary>
public class Position : AuditableEntity
{
    // === Quan hệ ===
    public Guid CompanyId { get; set; }
    public virtual Company Company { get; set; } = null!;

    // === Thông tin chính ===
    public string PositionCode { get; set; } = string.Empty;
    public string PositionName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsManagerLevel { get; set; }

    // === Hệ thống ===
    public int SortOrder { get; set; }
    public bool IsActive { get; set; } = true;

    // === Navigation collections ===
    public virtual ICollection<Employee> Employees { get; private set; } = new List<Employee>();
}

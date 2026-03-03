using Vns.Erp.Domain.Common;

namespace Vns.Erp.Domain.MasterData.Entities;

/// <summary>
/// Chi nhánh công ty.
/// </summary>
public class CompanyBranch : AuditableEntity
{
    // === Quan hệ ===
    public Guid CompanyId { get; set; }
    public virtual Company Company { get; set; } = null!;

    // === Thông tin chính ===
    public string BranchCode { get; set; } = string.Empty;
    public string BranchName { get; set; } = string.Empty;

    // === Liên hệ ===
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Phone { get; set; }
    public string? Fax { get; set; }
    public string? Email { get; set; }
    public string? ManagerName { get; set; }

    // === Hệ thống ===
    public int SortOrder { get; set; }
    public bool IsActive { get; set; } = true;
    public string? Notes { get; set; }

    // === Navigation collections ===
    public virtual ICollection<Department> Departments { get; private set; } = new List<Department>();
    public virtual ICollection<Employee> Employees { get; private set; } = new List<Employee>();
}

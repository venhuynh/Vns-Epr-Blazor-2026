using Vns.Erp.Domain.Common;

namespace Vns.Erp.Domain.MasterData.Entities;

/// <summary>
/// Phòng ban — hỗ trợ cấu trúc cây phân cấp (self-referencing ParentDepartment).
/// </summary>
public class Department : AuditableEntity
{
    // === Quan hệ ===
    public Guid CompanyId { get; set; }
    public virtual Company Company { get; set; } = null!;

    public Guid? BranchId { get; set; }
    public virtual CompanyBranch? Branch { get; set; }

    public Guid? ParentDepartmentId { get; set; }
    public virtual Department? ParentDepartment { get; set; }

    // === Thông tin chính ===
    public string DepartmentCode { get; set; } = string.Empty;
    public string DepartmentName { get; set; } = string.Empty;
    public string? Description { get; set; }

    // === Hệ thống ===
    public int SortOrder { get; set; }
    public bool IsActive { get; set; } = true;

    // === Navigation collections ===
    public virtual ICollection<Department> SubDepartments { get; private set; } = new List<Department>();
    public virtual ICollection<Employee> Employees { get; private set; } = new List<Employee>();
}

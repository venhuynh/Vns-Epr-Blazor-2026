using Vns.Erp.Domain.Common;

namespace Vns.Erp.Domain.MasterData.Entities;

/// <summary>
/// Công ty — thực thể gốc của tổ chức. Hệ thống chỉ cho phép duy nhất một bản ghi.
/// </summary>
public class Company : AuditableEntity
{
    // === Thông tin chính ===
    public string CompanyCode { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public string? ShortName { get; set; }
    public string? TaxCode { get; set; }

    // === Người đại diện ===
    public string? RepresentativeName { get; set; }
    public string? RepresentativeTitle { get; set; }

    // === Liên hệ ===
    public string? Phone { get; set; }
    public string? Fax { get; set; }
    public string? Email { get; set; }
    public string? Website { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }

    // === Logo (stored as byte array instead of XAF MediaDataObject) ===
    public byte[]? Logo { get; set; }

    // === Hệ thống ===
    public bool IsActive { get; set; } = true;
    public string? Notes { get; set; }

    // === Navigation collections ===
    public virtual ICollection<CompanyBranch> Branches { get; private set; } = new List<CompanyBranch>();
    public virtual ICollection<Department> Departments { get; private set; } = new List<Department>();
    public virtual ICollection<Position> Positions { get; private set; } = new List<Position>();
    public virtual ICollection<Employee> Employees { get; private set; } = new List<Employee>();
}

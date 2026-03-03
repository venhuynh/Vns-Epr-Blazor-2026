using Vns.Erp.Domain.Common;
using Vns.Erp.Domain.MasterData.Enums;

namespace Vns.Erp.Domain.MasterData.Entities;

/// <summary>
/// Nhân viên — thuộc Công ty, có thể thuộc Chi nhánh, Phòng ban, Chức vụ.
/// </summary>
public class Employee : AuditableEntity
{
    // === Quan hệ ===
    public Guid CompanyId { get; set; }
    public virtual Company Company { get; set; } = null!;

    public Guid? BranchId { get; set; }
    public virtual CompanyBranch? Branch { get; set; }

    public Guid? DepartmentId { get; set; }
    public virtual Department? Department { get; set; }

    public Guid? PositionId { get; set; }
    public virtual Position? Position { get; set; }

    // === Thông tin cơ bản ===
    public string EmployeeCode { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public Gender? Gender { get; set; }
    public DateTime? BirthDate { get; set; }

    // === Giấy tờ tùy thân ===
    public string? IdentityNumber { get; set; }
    public DateTime? IdentityIssueDate { get; set; }
    public string? IdentityIssuePlace { get; set; }

    // === Liên hệ ===
    public string? Phone { get; set; }
    public string? Mobile { get; set; }
    public string? Email { get; set; }
    public string? PermanentAddress { get; set; }
    public string? CurrentAddress { get; set; }
    public string? Fax { get; set; }
    public string? LinkedIn { get; set; }
    public string? Skype { get; set; }
    public string? WeChat { get; set; }

    // === Công việc ===
    public DateTime? HireDate { get; set; }
    public DateTime? ResignDate { get; set; }

    // === Ngân hàng ===
    public string? BankAccountNumber { get; set; }
    public string? BankName { get; set; }
    public string? BankBranch { get; set; }

    // === Thuế & Bảo hiểm ===
    public string? PersonalTaxCode { get; set; }
    public string? SocialInsuranceNumber { get; set; }

    // === Avatar (stored as byte array instead of XAF MediaDataObject) ===
    public byte[]? Avatar { get; set; }

    // === Hệ thống ===
    public bool IsActive { get; set; } = true;
    public string? Notes { get; set; }

    // === Liên kết tài khoản ===
    public Guid? ApplicationUserId { get; set; }
}

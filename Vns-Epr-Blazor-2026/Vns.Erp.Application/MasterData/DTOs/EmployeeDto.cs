using Vns.Erp.Domain.MasterData.Enums;

namespace Vns.Erp.Application.MasterData.DTOs;

/// <summary>
/// DTO for Employee entity.
/// </summary>
public class EmployeeDto
{
    public Guid Id { get; set; }

    // === Quan hệ ===
    public Guid CompanyId { get; set; }
    public Guid? BranchId { get; set; }
    public Guid? DepartmentId { get; set; }
    public Guid? PositionId { get; set; }

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

    // === Hệ thống ===
    public bool IsActive { get; set; }
    public string? Notes { get; set; }
    public Guid? ApplicationUserId { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
}

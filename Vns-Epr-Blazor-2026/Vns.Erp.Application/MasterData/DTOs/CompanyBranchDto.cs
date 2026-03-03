namespace Vns.Erp.Application.MasterData.DTOs;

/// <summary>
/// DTO for CompanyBranch entity.
/// </summary>
public class CompanyBranchDto
{
    public Guid Id { get; set; }
    public Guid CompanyId { get; set; }
    public string BranchCode { get; set; } = string.Empty;
    public string BranchName { get; set; } = string.Empty;
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Phone { get; set; }
    public string? Fax { get; set; }
    public string? Email { get; set; }
    public string? ManagerName { get; set; }
    public int SortOrder { get; set; }
    public bool IsActive { get; set; }
    public string? Notes { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
}

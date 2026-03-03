using Vns.Erp.Domain.MasterData.Enums;

namespace Vns.Erp.Application.MasterData.DTOs;

public class BusinessPartnerContactDto
{
    public Guid Id { get; set; }
    public Guid SiteId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string? Position { get; set; }
    public string? Department { get; set; }
    public Gender? Gender { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? Phone { get; set; }
    public string? Mobile { get; set; }
    public string? Email { get; set; }
    public string? Fax { get; set; }
    public string? LinkedIn { get; set; }
    public string? Skype { get; set; }
    public string? WeChat { get; set; }
    public bool IsPrimary { get; set; }
    public bool IsActive { get; set; }
    public string? Notes { get; set; }
    public Guid? ApplicationUserId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
}

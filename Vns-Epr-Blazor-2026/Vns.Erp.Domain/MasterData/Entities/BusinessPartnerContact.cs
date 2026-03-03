using Vns.Erp.Domain.Common;
using Vns.Erp.Domain.MasterData.Enums;

namespace Vns.Erp.Domain.MasterData.Entities;

/// <summary>
/// Người liên hệ tại một địa điểm đối tác.
/// </summary>
public class BusinessPartnerContact : AuditableEntity
{
    // === Quan hệ ===
    public Guid SiteId { get; set; }
    public virtual BusinessPartnerSite Site { get; set; } = null!;

    // === Thông tin chính ===
    public string FullName { get; set; } = string.Empty;
    public string? Position { get; set; }
    public string? Department { get; set; }
    public Gender? Gender { get; set; }
    public DateTime? BirthDate { get; set; }

    // === Liên hệ ===
    public string? Phone { get; set; }
    public string? Mobile { get; set; }
    public string? Email { get; set; }
    public string? Fax { get; set; }

    // === Mạng xã hội ===
    public string? LinkedIn { get; set; }
    public string? Skype { get; set; }
    public string? WeChat { get; set; }

    // === Avatar (stored as byte array instead of XAF MediaDataObject) ===
    public byte[]? Avatar { get; set; }

    // === Hệ thống ===
    public bool IsPrimary { get; set; }
    public bool IsActive { get; set; } = true;
    public string? Notes { get; set; }

    // === Liên kết tài khoản ===
    public Guid? ApplicationUserId { get; set; }
}

using Vns.Erp.Domain.Common;
using Vns.Erp.Domain.MasterData.Enums;

namespace Vns.Erp.Domain.MasterData.Entities;

/// <summary>
/// Khách hàng / Nhà cung cấp / Đối tác.
/// </summary>
public class BusinessPartner : AuditableEntity
{
    // === Thông tin chính ===
    public string PartnerCode { get; set; } = string.Empty;
    public string PartnerName { get; set; } = string.Empty;
    public PartnerType? PartnerType { get; set; } = Enums.PartnerType.Customer;
    public string? TaxCode { get; set; }

    // === Liên hệ ===
    public string? Phone { get; set; }
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
    public virtual ICollection<BusinessPartnerCategory> Categories { get; private set; } = new List<BusinessPartnerCategory>();
    public virtual ICollection<BusinessPartnerSite> Sites { get; private set; } = new List<BusinessPartnerSite>();
}

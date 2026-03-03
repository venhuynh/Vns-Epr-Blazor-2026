using Vns.Erp.Domain.Common;
using Vns.Erp.Domain.MasterData.Enums;

namespace Vns.Erp.Domain.MasterData.Entities;

/// <summary>
/// Địa điểm (site) của đối tác — trụ sở, chi nhánh, kho hàng, nhà máy.
/// </summary>
public class BusinessPartnerSite : AuditableEntity
{
    // === Quan hệ ===
    public Guid PartnerId { get; set; }
    public virtual BusinessPartner Partner { get; set; } = null!;

    // === Thông tin chính ===
    public string SiteCode { get; set; } = string.Empty;
    public string SiteName { get; set; } = string.Empty;
    public SiteType? SiteType { get; set; } = Enums.SiteType.HeadOffice;

    // === Địa chỉ ===
    public string? Address { get; set; }
    public string? District { get; set; }
    public string? City { get; set; }
    public string? Province { get; set; }
    public string? Country { get; set; }
    public string? PostalCode { get; set; }

    // === Liên hệ ===
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? GoogleMapUrl { get; set; }

    // === Hệ thống ===
    public bool IsDefault { get; set; }
    public bool IsActive { get; set; } = true;
    public string? Notes { get; set; }

    // === Navigation collections ===
    public virtual ICollection<BusinessPartnerContact> Contacts { get; private set; } = new List<BusinessPartnerContact>();
}

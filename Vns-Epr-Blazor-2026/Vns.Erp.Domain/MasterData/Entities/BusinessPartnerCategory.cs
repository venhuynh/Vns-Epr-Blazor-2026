using Vns.Erp.Domain.Common;

namespace Vns.Erp.Domain.MasterData.Entities;

/// <summary>
/// Nhóm đối tác — cây phân cấp (self-referencing ParentCategory).
/// </summary>
public class BusinessPartnerCategory : AuditableEntity
{
    // === Quan hệ ===
    public Guid? ParentCategoryId { get; set; }
    public virtual BusinessPartnerCategory? ParentCategory { get; set; }

    // === Thông tin chính ===
    public string? CategoryCode { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string? Description { get; set; }

    // === Hệ thống ===
    public int SortOrder { get; set; }
    public bool IsActive { get; set; } = true;

    // === Navigation collections ===
    public virtual ICollection<BusinessPartnerCategory> SubCategories { get; private set; } = new List<BusinessPartnerCategory>();
    public virtual ICollection<BusinessPartner> Partners { get; private set; } = new List<BusinessPartner>();
}

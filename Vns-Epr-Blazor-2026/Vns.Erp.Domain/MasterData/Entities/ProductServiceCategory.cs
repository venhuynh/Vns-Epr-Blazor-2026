using Vns.Erp.Domain.Common;

namespace Vns.Erp.Domain.MasterData.Entities;

/// <summary>
/// Nhóm sản phẩm/dịch vụ — cây phân cấp (self-referencing ParentCategory).
/// </summary>
public class ProductServiceCategory : AuditableEntity
{
    // === Thông tin chính ===
    public string? CategoryCode { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int SortOrder { get; set; }
    public bool IsActive { get; set; } = true;

    // === Cây phân cấp ===
    public Guid? ParentCategoryId { get; set; }
    public virtual ProductServiceCategory? ParentCategory { get; set; }

    // === Navigation collections ===
    public virtual ICollection<ProductServiceCategory> SubCategories { get; private set; } = new List<ProductServiceCategory>();
    public virtual ICollection<ProductService> Products { get; private set; } = new List<ProductService>();
}

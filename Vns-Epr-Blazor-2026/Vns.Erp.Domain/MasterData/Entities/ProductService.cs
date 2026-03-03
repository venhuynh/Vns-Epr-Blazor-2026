using Vns.Erp.Domain.Common;

namespace Vns.Erp.Domain.MasterData.Entities;

/// <summary>
/// Sản phẩm / Dịch vụ — thực thể chính của module sản phẩm.
/// </summary>
public class ProductService : AuditableEntity
{
    // === Thông tin chính ===
    public string ProductCode { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public bool IsService { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;

    // === Nhóm SP/DV ===
    public Guid? CategoryId { get; set; }
    public virtual ProductServiceCategory? Category { get; set; }

    // === Hình ảnh (stored as byte array instead of XAF MediaDataObject) ===
    public byte[]? Thumbnail { get; set; }

    // === Navigation collections ===
    public virtual ICollection<ProductVariant> Variants { get; private set; } = new List<ProductVariant>();
}

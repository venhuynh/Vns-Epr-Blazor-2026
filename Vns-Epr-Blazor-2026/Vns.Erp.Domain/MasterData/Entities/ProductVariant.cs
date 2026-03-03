using Vns.Erp.Domain.Common;

namespace Vns.Erp.Domain.MasterData.Entities;

/// <summary>
/// Biến thể sản phẩm — mỗi sản phẩm có thể có nhiều biến thể (SKU riêng).
/// </summary>
public class ProductVariant : AuditableEntity
{
    // === Quan hệ ===
    public Guid? ProductId { get; set; }
    public virtual ProductService? Product { get; set; }

    // === Thông tin chính ===
    public string VariantCode { get; set; } = string.Empty;
    public string? VariantFullName { get; set; }
    public string? VariantNameForReport { get; set; }
    public bool IsActive { get; set; } = true;

    // === Đơn vị tính ===
    public Guid? UnitId { get; set; }
    public virtual UnitOfMeasure? Unit { get; set; }

    // === Hình ảnh (stored as byte array instead of XAF MediaDataObject) ===
    public byte[]? Thumbnail { get; set; }

    // === Navigation collections ===
    public virtual ICollection<VariantAttributeLink> AttributeLinks { get; private set; } = new List<VariantAttributeLink>();
}

using Vns.Erp.Domain.Common;

namespace Vns.Erp.Domain.MasterData.Entities;

/// <summary>
/// Giá trị thuộc tính (VD: Đỏ, Xanh cho thuộc tính Màu sắc).
/// </summary>
public class ProductAttributeValue : AuditableEntity
{
    // === Quan hệ ===
    public Guid? ProductAttributeId { get; set; }
    public virtual ProductAttribute? Attribute { get; set; }

    // === Thông tin chính ===
    public string Value { get; set; } = string.Empty;
}

using Vns.Erp.Domain.Common;

namespace Vns.Erp.Domain.MasterData.Entities;

/// <summary>
/// Thuộc tính sản phẩm (VD: Màu sắc, Kích thước, Chất liệu).
/// </summary>
public class ProductAttribute : AuditableEntity
{
    // === Thông tin chính ===
    public string AttributeName { get; set; } = string.Empty;
    public string DataType { get; set; } = string.Empty;
    public string? Description { get; set; }

    // === Navigation collections ===
    public virtual ICollection<ProductAttributeValue> Values { get; private set; } = new List<ProductAttributeValue>();
}

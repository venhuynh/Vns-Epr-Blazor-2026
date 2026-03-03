using Vns.Erp.Domain.Common;

namespace Vns.Erp.Domain.MasterData.Entities;

/// <summary>
/// Liên kết Biến thể ↔ Thuộc tính ↔ Giá trị (junction entity — 3 FK).
/// </summary>
public class VariantAttributeLink : AuditableEntity
{
    // === Variant FK ===
    public Guid? ProductVariantId { get; set; }
    public virtual ProductVariant? Variant { get; set; }

    // === Attribute FK ===
    public Guid? ProductAttributeId { get; set; }
    public virtual ProductAttribute? Attribute { get; set; }

    // === Attribute Value FK ===
    public Guid? ProductAttributeValueId { get; set; }
    public virtual ProductAttributeValue? AttributeValue { get; set; }
}

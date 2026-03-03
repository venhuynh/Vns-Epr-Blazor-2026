using Vns.Erp.Domain.Common;

namespace Vns.Erp.Domain.MasterData.Entities;

/// <summary>
/// Đơn vị tính — lookup table dùng cho ProductVariant.
/// </summary>
public class UnitOfMeasure : AuditableEntity
{
    // === Thông tin chính ===
    public string UnitCode { get; set; } = string.Empty;
    public string UnitName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;

    // === Navigation collections ===
    public virtual ICollection<ProductVariant> ProductVariants { get; private set; } = new List<ProductVariant>();
}

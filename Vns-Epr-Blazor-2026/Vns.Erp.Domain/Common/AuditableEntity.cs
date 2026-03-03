namespace Vns.Erp.Domain.Common;

/// <summary>
/// Extends BaseEntity with auditable fields tracking who created/modified the entity.
/// </summary>
public abstract class AuditableEntity : BaseEntity
{
    public string? CreatedBy { get; set; }
    public string? ModifiedBy { get; set; }
}

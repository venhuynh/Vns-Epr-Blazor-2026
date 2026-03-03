namespace Vns.Erp.Application.MasterData.DTOs;

public class ProductVariantDto
{
    public Guid Id { get; set; }
    public Guid? ProductId { get; set; }
    public string VariantCode { get; set; } = string.Empty;
    public string? VariantFullName { get; set; }
    public string? VariantNameForReport { get; set; }
    public bool IsActive { get; set; }
    public Guid? UnitId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
}

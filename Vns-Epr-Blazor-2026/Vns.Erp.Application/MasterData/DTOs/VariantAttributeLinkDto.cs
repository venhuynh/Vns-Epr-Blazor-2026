namespace Vns.Erp.Application.MasterData.DTOs;

public class VariantAttributeLinkDto
{
    public Guid Id { get; set; }
    public Guid? ProductVariantId { get; set; }
    public Guid? ProductAttributeId { get; set; }
    public Guid? ProductAttributeValueId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
}

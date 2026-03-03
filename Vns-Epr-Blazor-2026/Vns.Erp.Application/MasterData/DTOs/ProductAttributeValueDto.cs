namespace Vns.Erp.Application.MasterData.DTOs;

public class ProductAttributeValueDto
{
    public Guid Id { get; set; }
    public Guid? ProductAttributeId { get; set; }
    public string Value { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
}

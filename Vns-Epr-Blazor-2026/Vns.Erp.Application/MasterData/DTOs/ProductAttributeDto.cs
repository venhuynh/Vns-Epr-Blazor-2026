namespace Vns.Erp.Application.MasterData.DTOs;

public class ProductAttributeDto
{
    public Guid Id { get; set; }
    public string AttributeName { get; set; } = string.Empty;
    public string DataType { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
}

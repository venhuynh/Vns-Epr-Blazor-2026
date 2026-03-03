namespace Vns.Erp.Application.MasterData.DTOs;

/// <summary>
/// DTO for UnitOfMeasure entity — read/write operations.
/// </summary>
public class UnitOfMeasureDto
{
    public Guid Id { get; set; }
    public string UnitCode { get; set; } = string.Empty;
    public string UnitName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
}

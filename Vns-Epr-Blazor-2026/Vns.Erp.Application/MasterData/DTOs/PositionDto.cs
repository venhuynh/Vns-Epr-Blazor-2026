namespace Vns.Erp.Application.MasterData.DTOs;

/// <summary>
/// DTO for Position entity.
/// </summary>
public class PositionDto
{
    public Guid Id { get; set; }
    public Guid CompanyId { get; set; }
    public string PositionCode { get; set; } = string.Empty;
    public string PositionName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsManagerLevel { get; set; }
    public int SortOrder { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
}

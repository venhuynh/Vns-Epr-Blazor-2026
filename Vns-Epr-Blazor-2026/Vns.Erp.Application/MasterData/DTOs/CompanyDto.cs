namespace Vns.Erp.Application.MasterData.DTOs;

/// <summary>
/// DTO for Company entity — read/write operations.
/// </summary>
public class CompanyDto
{
    public Guid Id { get; set; }
    public string CompanyCode { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public string? ShortName { get; set; }
    public string? TaxCode { get; set; }
    public string? RepresentativeName { get; set; }
    public string? RepresentativeTitle { get; set; }
    public string? Phone { get; set; }
    public string? Fax { get; set; }
    public string? Email { get; set; }
    public string? Website { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public bool IsActive { get; set; }
    public string? Notes { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
}

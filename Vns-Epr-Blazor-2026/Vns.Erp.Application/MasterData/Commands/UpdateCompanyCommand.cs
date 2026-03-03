using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;

namespace Vns.Erp.Application.MasterData.Commands;

/// <summary>
/// Updates an existing Company entity.
/// </summary>
public record UpdateCompanyCommand : IRequest<CompanyDto>
{
    public Guid Id { get; init; }
    public string CompanyCode { get; init; } = string.Empty;
    public string CompanyName { get; init; } = string.Empty;
    public string? ShortName { get; init; }
    public string? TaxCode { get; init; }
    public string? RepresentativeName { get; init; }
    public string? RepresentativeTitle { get; init; }
    public string? Phone { get; init; }
    public string? Fax { get; init; }
    public string? Email { get; init; }
    public string? Website { get; init; }
    public string? Address { get; init; }
    public string? City { get; init; }
    public string? Country { get; init; }
    public bool IsActive { get; init; }
    public string? Notes { get; init; }
}

public class UpdateCompanyCommandHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<UpdateCompanyCommand, CompanyDto>
{
    public async Task<CompanyDto> Handle(
        UpdateCompanyCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await context.Companies
            .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"Company with Id '{request.Id}' not found.");

        entity.CompanyCode = request.CompanyCode;
        entity.CompanyName = request.CompanyName;
        entity.ShortName = request.ShortName;
        entity.TaxCode = request.TaxCode;
        entity.RepresentativeName = request.RepresentativeName;
        entity.RepresentativeTitle = request.RepresentativeTitle;
        entity.Phone = request.Phone;
        entity.Fax = request.Fax;
        entity.Email = request.Email;
        entity.Website = request.Website;
        entity.Address = request.Address;
        entity.City = request.City;
        entity.Country = request.Country;
        entity.IsActive = request.IsActive;
        entity.Notes = request.Notes;
        entity.ModifiedDate = DateTime.UtcNow;

        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<CompanyDto>(entity);
    }
}

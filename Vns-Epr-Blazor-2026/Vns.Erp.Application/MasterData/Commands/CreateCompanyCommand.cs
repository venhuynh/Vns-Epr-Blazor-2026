using AutoMapper;
using MediatR;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;
using Vns.Erp.Domain.MasterData.Entities;

namespace Vns.Erp.Application.MasterData.Commands;

/// <summary>
/// Creates a new Company entity.
/// </summary>
public record CreateCompanyCommand : IRequest<CompanyDto>
{
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
}

public class CreateCompanyCommandHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<CreateCompanyCommand, CompanyDto>
{
    public async Task<CompanyDto> Handle(
        CreateCompanyCommand request,
        CancellationToken cancellationToken)
    {
        var entity = new Company
        {
            CompanyCode = request.CompanyCode,
            CompanyName = request.CompanyName,
            ShortName = request.ShortName,
            TaxCode = request.TaxCode,
            RepresentativeName = request.RepresentativeName,
            RepresentativeTitle = request.RepresentativeTitle,
            Phone = request.Phone,
            Fax = request.Fax,
            Email = request.Email,
            Website = request.Website,
            Address = request.Address,
            City = request.City,
            Country = request.Country,
            IsActive = true
        };

        context.Companies.Add(entity);
        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<CompanyDto>(entity);
    }
}

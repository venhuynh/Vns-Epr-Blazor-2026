using AutoMapper;
using MediatR;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;
using Vns.Erp.Domain.MasterData.Entities;
using Vns.Erp.Domain.MasterData.Enums;

namespace Vns.Erp.Application.MasterData.Commands;

public record CreateBusinessPartnerCommand : IRequest<BusinessPartnerDto>
{
    public string PartnerCode { get; init; } = string.Empty;
    public string PartnerName { get; init; } = string.Empty;
    public PartnerType? PartnerType { get; init; }
    public string? TaxCode { get; init; }
    public string? Phone { get; init; }
    public string? Email { get; init; }
    public string? Website { get; init; }
    public string? Address { get; init; }
    public string? City { get; init; }
    public string? Country { get; init; }
    public string? Notes { get; init; }
}

public class CreateBusinessPartnerCommandHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<CreateBusinessPartnerCommand, BusinessPartnerDto>
{
    public async Task<BusinessPartnerDto> Handle(
        CreateBusinessPartnerCommand request,
        CancellationToken cancellationToken)
    {
        var entity = new BusinessPartner
        {
            PartnerCode = request.PartnerCode,
            PartnerName = request.PartnerName,
            PartnerType = request.PartnerType,
            TaxCode = request.TaxCode,
            Phone = request.Phone,
            Email = request.Email,
            Website = request.Website,
            Address = request.Address,
            City = request.City,
            Country = request.Country,
            Notes = request.Notes,
            IsActive = true
        };

        context.BusinessPartners.Add(entity);
        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<BusinessPartnerDto>(entity);
    }
}

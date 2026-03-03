using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;
using Vns.Erp.Domain.MasterData.Enums;

namespace Vns.Erp.Application.MasterData.Commands;

public record UpdateBusinessPartnerCommand : IRequest<BusinessPartnerDto>
{
    public Guid Id { get; init; }
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
    public bool IsActive { get; init; }
    public string? Notes { get; init; }
}

public class UpdateBusinessPartnerCommandHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<UpdateBusinessPartnerCommand, BusinessPartnerDto>
{
    public async Task<BusinessPartnerDto> Handle(
        UpdateBusinessPartnerCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await context.BusinessPartners
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"BusinessPartner with Id '{request.Id}' not found.");

        entity.PartnerCode = request.PartnerCode;
        entity.PartnerName = request.PartnerName;
        entity.PartnerType = request.PartnerType;
        entity.TaxCode = request.TaxCode;
        entity.Phone = request.Phone;
        entity.Email = request.Email;
        entity.Website = request.Website;
        entity.Address = request.Address;
        entity.City = request.City;
        entity.Country = request.Country;
        entity.IsActive = request.IsActive;
        entity.Notes = request.Notes;
        entity.ModifiedDate = DateTime.UtcNow;

        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<BusinessPartnerDto>(entity);
    }
}

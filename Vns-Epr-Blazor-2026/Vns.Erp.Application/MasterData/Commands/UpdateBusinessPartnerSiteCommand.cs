using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;
using Vns.Erp.Domain.MasterData.Enums;

namespace Vns.Erp.Application.MasterData.Commands;

public record UpdateBusinessPartnerSiteCommand : IRequest<BusinessPartnerSiteDto>
{
    public Guid Id { get; init; }
    public Guid PartnerId { get; init; }
    public string SiteCode { get; init; } = string.Empty;
    public string SiteName { get; init; } = string.Empty;
    public SiteType? SiteType { get; init; }
    public string? Address { get; init; }
    public string? District { get; init; }
    public string? City { get; init; }
    public string? Province { get; init; }
    public string? Country { get; init; }
    public string? PostalCode { get; init; }
    public string? Phone { get; init; }
    public string? Email { get; init; }
    public string? GoogleMapUrl { get; init; }
    public bool IsDefault { get; init; }
    public bool IsActive { get; init; }
    public string? Notes { get; init; }
}

public class UpdateBusinessPartnerSiteCommandHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<UpdateBusinessPartnerSiteCommand, BusinessPartnerSiteDto>
{
    public async Task<BusinessPartnerSiteDto> Handle(
        UpdateBusinessPartnerSiteCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await context.BusinessPartnerSites
            .FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"BusinessPartnerSite with Id '{request.Id}' not found.");

        entity.PartnerId = request.PartnerId;
        entity.SiteCode = request.SiteCode;
        entity.SiteName = request.SiteName;
        entity.SiteType = request.SiteType;
        entity.Address = request.Address;
        entity.District = request.District;
        entity.City = request.City;
        entity.Province = request.Province;
        entity.Country = request.Country;
        entity.PostalCode = request.PostalCode;
        entity.Phone = request.Phone;
        entity.Email = request.Email;
        entity.GoogleMapUrl = request.GoogleMapUrl;
        entity.IsDefault = request.IsDefault;
        entity.IsActive = request.IsActive;
        entity.Notes = request.Notes;
        entity.ModifiedDate = DateTime.UtcNow;

        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<BusinessPartnerSiteDto>(entity);
    }
}

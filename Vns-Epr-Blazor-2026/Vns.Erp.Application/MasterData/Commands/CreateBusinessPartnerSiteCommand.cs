using AutoMapper;
using MediatR;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;
using Vns.Erp.Domain.MasterData.Entities;
using Vns.Erp.Domain.MasterData.Enums;

namespace Vns.Erp.Application.MasterData.Commands;

public record CreateBusinessPartnerSiteCommand : IRequest<BusinessPartnerSiteDto>
{
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
    public string? Notes { get; init; }
}

public class CreateBusinessPartnerSiteCommandHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<CreateBusinessPartnerSiteCommand, BusinessPartnerSiteDto>
{
    public async Task<BusinessPartnerSiteDto> Handle(
        CreateBusinessPartnerSiteCommand request,
        CancellationToken cancellationToken)
    {
        var entity = new BusinessPartnerSite
        {
            PartnerId = request.PartnerId,
            SiteCode = request.SiteCode,
            SiteName = request.SiteName,
            SiteType = request.SiteType,
            Address = request.Address,
            District = request.District,
            City = request.City,
            Province = request.Province,
            Country = request.Country,
            PostalCode = request.PostalCode,
            Phone = request.Phone,
            Email = request.Email,
            GoogleMapUrl = request.GoogleMapUrl,
            IsDefault = request.IsDefault,
            Notes = request.Notes,
            IsActive = true
        };

        context.BusinessPartnerSites.Add(entity);
        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<BusinessPartnerSiteDto>(entity);
    }
}

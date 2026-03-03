using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;

namespace Vns.Erp.Application.MasterData.Queries;

public record GetBusinessPartnerSiteListQuery(Guid PartnerId) : IRequest<List<BusinessPartnerSiteDto>>;

public class GetBusinessPartnerSiteListQueryHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<GetBusinessPartnerSiteListQuery, List<BusinessPartnerSiteDto>>
{
    public async Task<List<BusinessPartnerSiteDto>> Handle(
        GetBusinessPartnerSiteListQuery request,
        CancellationToken cancellationToken)
    {
        return await context.BusinessPartnerSites
            .AsNoTracking()
            .Where(s => s.PartnerId == request.PartnerId)
            .OrderBy(s => s.SiteCode)
            .ProjectTo<BusinessPartnerSiteDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}

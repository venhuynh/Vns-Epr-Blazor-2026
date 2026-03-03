using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;

namespace Vns.Erp.Application.MasterData.Queries;

public record GetBusinessPartnerContactListQuery(Guid SiteId) : IRequest<List<BusinessPartnerContactDto>>;

public class GetBusinessPartnerContactListQueryHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<GetBusinessPartnerContactListQuery, List<BusinessPartnerContactDto>>
{
    public async Task<List<BusinessPartnerContactDto>> Handle(
        GetBusinessPartnerContactListQuery request,
        CancellationToken cancellationToken)
    {
        return await context.BusinessPartnerContacts
            .AsNoTracking()
            .Where(c => c.SiteId == request.SiteId)
            .OrderBy(c => c.FullName)
            .ProjectTo<BusinessPartnerContactDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}

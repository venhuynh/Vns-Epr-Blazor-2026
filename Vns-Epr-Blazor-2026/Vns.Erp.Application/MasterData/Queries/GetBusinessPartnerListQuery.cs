using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;

namespace Vns.Erp.Application.MasterData.Queries;

public record GetBusinessPartnerListQuery : IRequest<List<BusinessPartnerDto>>;

public class GetBusinessPartnerListQueryHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<GetBusinessPartnerListQuery, List<BusinessPartnerDto>>
{
    public async Task<List<BusinessPartnerDto>> Handle(
        GetBusinessPartnerListQuery request,
        CancellationToken cancellationToken)
    {
        return await context.BusinessPartners
            .AsNoTracking()
            .OrderBy(p => p.PartnerCode)
            .ProjectTo<BusinessPartnerDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}

using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;

namespace Vns.Erp.Application.MasterData.Queries;

public record GetPositionListQuery(Guid CompanyId) : IRequest<List<PositionDto>>;

public class GetPositionListQueryHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<GetPositionListQuery, List<PositionDto>>
{
    public async Task<List<PositionDto>> Handle(
        GetPositionListQuery request,
        CancellationToken cancellationToken)
    {
        return await context.Positions
            .AsNoTracking()
            .Where(p => p.CompanyId == request.CompanyId)
            .OrderBy(p => p.SortOrder).ThenBy(p => p.PositionCode)
            .ProjectTo<PositionDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}

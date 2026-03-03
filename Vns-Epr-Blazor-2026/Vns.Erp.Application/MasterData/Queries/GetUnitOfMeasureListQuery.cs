using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;

namespace Vns.Erp.Application.MasterData.Queries;

/// <summary>
/// Returns a list of all UnitOfMeasure records.
/// </summary>
public record GetUnitOfMeasureListQuery : IRequest<List<UnitOfMeasureDto>>;

public class GetUnitOfMeasureListQueryHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<GetUnitOfMeasureListQuery, List<UnitOfMeasureDto>>
{
    public async Task<List<UnitOfMeasureDto>> Handle(
        GetUnitOfMeasureListQuery request,
        CancellationToken cancellationToken)
    {
        return await context.UnitsOfMeasure
            .AsNoTracking()
            .OrderBy(u => u.UnitCode)
            .ProjectTo<UnitOfMeasureDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}

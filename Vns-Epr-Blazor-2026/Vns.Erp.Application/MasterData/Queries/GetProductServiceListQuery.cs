using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;

namespace Vns.Erp.Application.MasterData.Queries;

public record GetProductServiceListQuery : IRequest<List<ProductServiceDto>>;

public class GetProductServiceListQueryHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<GetProductServiceListQuery, List<ProductServiceDto>>
{
    public async Task<List<ProductServiceDto>> Handle(
        GetProductServiceListQuery request, CancellationToken cancellationToken)
    {
        return await context.ProductServices
            .AsNoTracking()
            .OrderBy(p => p.ProductCode)
            .ProjectTo<ProductServiceDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}

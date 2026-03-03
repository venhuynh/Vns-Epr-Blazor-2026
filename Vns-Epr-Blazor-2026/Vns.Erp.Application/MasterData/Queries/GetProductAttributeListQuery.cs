using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;

namespace Vns.Erp.Application.MasterData.Queries;

public record GetProductAttributeListQuery : IRequest<List<ProductAttributeDto>>;

public class GetProductAttributeListQueryHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<GetProductAttributeListQuery, List<ProductAttributeDto>>
{
    public async Task<List<ProductAttributeDto>> Handle(
        GetProductAttributeListQuery request, CancellationToken cancellationToken)
    {
        return await context.ProductAttributes
            .AsNoTracking()
            .OrderBy(a => a.AttributeName)
            .ProjectTo<ProductAttributeDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}

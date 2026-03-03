using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;

namespace Vns.Erp.Application.MasterData.Queries;

public record GetProductVariantListQuery(Guid ProductId) : IRequest<List<ProductVariantDto>>;

public class GetProductVariantListQueryHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<GetProductVariantListQuery, List<ProductVariantDto>>
{
    public async Task<List<ProductVariantDto>> Handle(
        GetProductVariantListQuery request, CancellationToken cancellationToken)
    {
        return await context.ProductVariants
            .AsNoTracking()
            .Where(v => v.ProductId == request.ProductId)
            .OrderBy(v => v.VariantCode)
            .ProjectTo<ProductVariantDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}

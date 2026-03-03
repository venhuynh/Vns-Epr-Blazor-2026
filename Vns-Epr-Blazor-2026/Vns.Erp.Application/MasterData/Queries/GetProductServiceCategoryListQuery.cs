using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;

namespace Vns.Erp.Application.MasterData.Queries;

public record GetProductServiceCategoryListQuery : IRequest<List<ProductServiceCategoryDto>>;

public class GetProductServiceCategoryListQueryHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<GetProductServiceCategoryListQuery, List<ProductServiceCategoryDto>>
{
    public async Task<List<ProductServiceCategoryDto>> Handle(
        GetProductServiceCategoryListQuery request, CancellationToken cancellationToken)
    {
        return await context.ProductServiceCategories
            .AsNoTracking()
            .OrderBy(c => c.SortOrder).ThenBy(c => c.CategoryName)
            .ProjectTo<ProductServiceCategoryDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}

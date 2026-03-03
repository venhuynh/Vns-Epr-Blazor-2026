using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;

namespace Vns.Erp.Application.MasterData.Queries;

public record GetProductAttributeValueListQuery(Guid AttributeId) : IRequest<List<ProductAttributeValueDto>>;

public class GetProductAttributeValueListQueryHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<GetProductAttributeValueListQuery, List<ProductAttributeValueDto>>
{
    public async Task<List<ProductAttributeValueDto>> Handle(
        GetProductAttributeValueListQuery request, CancellationToken cancellationToken)
    {
        return await context.ProductAttributeValues
            .AsNoTracking()
            .Where(v => v.ProductAttributeId == request.AttributeId)
            .OrderBy(v => v.Value)
            .ProjectTo<ProductAttributeValueDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}

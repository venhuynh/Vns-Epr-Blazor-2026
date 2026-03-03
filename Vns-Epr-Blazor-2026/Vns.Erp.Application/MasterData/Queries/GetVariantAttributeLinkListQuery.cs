using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;

namespace Vns.Erp.Application.MasterData.Queries;

public record GetVariantAttributeLinkListQuery(Guid VariantId) : IRequest<List<VariantAttributeLinkDto>>;

public class GetVariantAttributeLinkListQueryHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<GetVariantAttributeLinkListQuery, List<VariantAttributeLinkDto>>
{
    public async Task<List<VariantAttributeLinkDto>> Handle(
        GetVariantAttributeLinkListQuery request, CancellationToken cancellationToken)
    {
        return await context.VariantAttributeLinks
            .AsNoTracking()
            .Where(l => l.ProductVariantId == request.VariantId)
            .ProjectTo<VariantAttributeLinkDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}

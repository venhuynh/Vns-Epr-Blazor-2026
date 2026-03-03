using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;

namespace Vns.Erp.Application.MasterData.Queries;

public record GetBusinessPartnerCategoryListQuery : IRequest<List<BusinessPartnerCategoryDto>>;

public class GetBusinessPartnerCategoryListQueryHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<GetBusinessPartnerCategoryListQuery, List<BusinessPartnerCategoryDto>>
{
    public async Task<List<BusinessPartnerCategoryDto>> Handle(
        GetBusinessPartnerCategoryListQuery request,
        CancellationToken cancellationToken)
    {
        return await context.BusinessPartnerCategories
            .AsNoTracking()
            .OrderBy(c => c.SortOrder).ThenBy(c => c.CategoryName)
            .ProjectTo<BusinessPartnerCategoryDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}

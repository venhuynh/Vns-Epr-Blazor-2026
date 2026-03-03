using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;

namespace Vns.Erp.Application.MasterData.Queries;

public record GetCompanyBranchListQuery(Guid CompanyId) : IRequest<List<CompanyBranchDto>>;

public class GetCompanyBranchListQueryHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<GetCompanyBranchListQuery, List<CompanyBranchDto>>
{
    public async Task<List<CompanyBranchDto>> Handle(
        GetCompanyBranchListQuery request,
        CancellationToken cancellationToken)
    {
        return await context.CompanyBranches
            .AsNoTracking()
            .Where(b => b.CompanyId == request.CompanyId)
            .OrderBy(b => b.SortOrder).ThenBy(b => b.BranchCode)
            .ProjectTo<CompanyBranchDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}

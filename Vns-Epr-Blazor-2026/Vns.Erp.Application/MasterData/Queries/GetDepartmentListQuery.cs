using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;

namespace Vns.Erp.Application.MasterData.Queries;

public record GetDepartmentListQuery(Guid CompanyId) : IRequest<List<DepartmentDto>>;

public class GetDepartmentListQueryHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<GetDepartmentListQuery, List<DepartmentDto>>
{
    public async Task<List<DepartmentDto>> Handle(
        GetDepartmentListQuery request,
        CancellationToken cancellationToken)
    {
        return await context.Departments
            .AsNoTracking()
            .Where(d => d.CompanyId == request.CompanyId)
            .OrderBy(d => d.SortOrder).ThenBy(d => d.DepartmentCode)
            .ProjectTo<DepartmentDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}

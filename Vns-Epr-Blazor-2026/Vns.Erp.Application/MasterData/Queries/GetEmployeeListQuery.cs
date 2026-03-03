using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;

namespace Vns.Erp.Application.MasterData.Queries;

public record GetEmployeeListQuery(Guid CompanyId) : IRequest<List<EmployeeDto>>;

public class GetEmployeeListQueryHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<GetEmployeeListQuery, List<EmployeeDto>>
{
    public async Task<List<EmployeeDto>> Handle(
        GetEmployeeListQuery request,
        CancellationToken cancellationToken)
    {
        return await context.Employees
            .AsNoTracking()
            .Where(e => e.CompanyId == request.CompanyId)
            .OrderBy(e => e.EmployeeCode)
            .ProjectTo<EmployeeDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}

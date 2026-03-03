using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;

namespace Vns.Erp.Application.MasterData.Queries;

/// <summary>
/// Returns a list of all Company records.
/// </summary>
public record GetCompanyListQuery : IRequest<List<CompanyDto>>;

public class GetCompanyListQueryHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<GetCompanyListQuery, List<CompanyDto>>
{
    public async Task<List<CompanyDto>> Handle(
        GetCompanyListQuery request,
        CancellationToken cancellationToken)
    {
        return await context.Companies
            .AsNoTracking()
            .OrderBy(c => c.CompanyCode)
            .ProjectTo<CompanyDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}

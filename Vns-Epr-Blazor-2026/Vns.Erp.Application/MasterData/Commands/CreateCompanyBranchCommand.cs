using AutoMapper;
using MediatR;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;
using Vns.Erp.Domain.MasterData.Entities;

namespace Vns.Erp.Application.MasterData.Commands;

public record CreateCompanyBranchCommand : IRequest<CompanyBranchDto>
{
    public Guid CompanyId { get; init; }
    public string BranchCode { get; init; } = string.Empty;
    public string BranchName { get; init; } = string.Empty;
    public string? Address { get; init; }
    public string? City { get; init; }
    public string? Phone { get; init; }
    public string? Fax { get; init; }
    public string? Email { get; init; }
    public string? ManagerName { get; init; }
    public int SortOrder { get; init; }
    public string? Notes { get; init; }
}

public class CreateCompanyBranchCommandHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<CreateCompanyBranchCommand, CompanyBranchDto>
{
    public async Task<CompanyBranchDto> Handle(
        CreateCompanyBranchCommand request,
        CancellationToken cancellationToken)
    {
        var entity = new CompanyBranch
        {
            CompanyId = request.CompanyId,
            BranchCode = request.BranchCode,
            BranchName = request.BranchName,
            Address = request.Address,
            City = request.City,
            Phone = request.Phone,
            Fax = request.Fax,
            Email = request.Email,
            ManagerName = request.ManagerName,
            SortOrder = request.SortOrder,
            Notes = request.Notes,
            IsActive = true
        };

        context.CompanyBranches.Add(entity);
        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<CompanyBranchDto>(entity);
    }
}

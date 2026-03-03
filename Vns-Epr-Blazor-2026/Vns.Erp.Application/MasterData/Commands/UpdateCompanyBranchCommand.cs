using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;

namespace Vns.Erp.Application.MasterData.Commands;

public record UpdateCompanyBranchCommand : IRequest<CompanyBranchDto>
{
    public Guid Id { get; init; }
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
    public bool IsActive { get; init; }
    public string? Notes { get; init; }
}

public class UpdateCompanyBranchCommandHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<UpdateCompanyBranchCommand, CompanyBranchDto>
{
    public async Task<CompanyBranchDto> Handle(
        UpdateCompanyBranchCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await context.CompanyBranches
            .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"CompanyBranch with Id '{request.Id}' not found.");

        entity.CompanyId = request.CompanyId;
        entity.BranchCode = request.BranchCode;
        entity.BranchName = request.BranchName;
        entity.Address = request.Address;
        entity.City = request.City;
        entity.Phone = request.Phone;
        entity.Fax = request.Fax;
        entity.Email = request.Email;
        entity.ManagerName = request.ManagerName;
        entity.SortOrder = request.SortOrder;
        entity.IsActive = request.IsActive;
        entity.Notes = request.Notes;
        entity.ModifiedDate = DateTime.UtcNow;

        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<CompanyBranchDto>(entity);
    }
}

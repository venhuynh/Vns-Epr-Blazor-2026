using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;

namespace Vns.Erp.Application.MasterData.Commands;

public record UpdateDepartmentCommand : IRequest<DepartmentDto>
{
    public Guid Id { get; init; }
    public Guid CompanyId { get; init; }
    public Guid? BranchId { get; init; }
    public Guid? ParentDepartmentId { get; init; }
    public string DepartmentCode { get; init; } = string.Empty;
    public string DepartmentName { get; init; } = string.Empty;
    public string? Description { get; init; }
    public int SortOrder { get; init; }
    public bool IsActive { get; init; }
}

public class UpdateDepartmentCommandHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<UpdateDepartmentCommand, DepartmentDto>
{
    public async Task<DepartmentDto> Handle(
        UpdateDepartmentCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await context.Departments
            .FirstOrDefaultAsync(d => d.Id == request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"Department with Id '{request.Id}' not found.");

        entity.CompanyId = request.CompanyId;
        entity.BranchId = request.BranchId;
        entity.ParentDepartmentId = request.ParentDepartmentId;
        entity.DepartmentCode = request.DepartmentCode;
        entity.DepartmentName = request.DepartmentName;
        entity.Description = request.Description;
        entity.SortOrder = request.SortOrder;
        entity.IsActive = request.IsActive;
        entity.ModifiedDate = DateTime.UtcNow;

        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<DepartmentDto>(entity);
    }
}

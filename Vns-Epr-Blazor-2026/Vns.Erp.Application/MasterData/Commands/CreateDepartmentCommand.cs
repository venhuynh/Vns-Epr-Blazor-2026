using AutoMapper;
using MediatR;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;
using Vns.Erp.Domain.MasterData.Entities;

namespace Vns.Erp.Application.MasterData.Commands;

public record CreateDepartmentCommand : IRequest<DepartmentDto>
{
    public Guid CompanyId { get; init; }
    public Guid? BranchId { get; init; }
    public Guid? ParentDepartmentId { get; init; }
    public string DepartmentCode { get; init; } = string.Empty;
    public string DepartmentName { get; init; } = string.Empty;
    public string? Description { get; init; }
    public int SortOrder { get; init; }
}

public class CreateDepartmentCommandHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<CreateDepartmentCommand, DepartmentDto>
{
    public async Task<DepartmentDto> Handle(
        CreateDepartmentCommand request,
        CancellationToken cancellationToken)
    {
        var entity = new Department
        {
            CompanyId = request.CompanyId,
            BranchId = request.BranchId,
            ParentDepartmentId = request.ParentDepartmentId,
            DepartmentCode = request.DepartmentCode,
            DepartmentName = request.DepartmentName,
            Description = request.Description,
            SortOrder = request.SortOrder,
            IsActive = true
        };

        context.Departments.Add(entity);
        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<DepartmentDto>(entity);
    }
}

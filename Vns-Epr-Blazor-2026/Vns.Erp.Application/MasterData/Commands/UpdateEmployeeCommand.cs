using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;
using Vns.Erp.Domain.MasterData.Enums;

namespace Vns.Erp.Application.MasterData.Commands;

public record UpdateEmployeeCommand : IRequest<EmployeeDto>
{
    public Guid Id { get; init; }
    public Guid CompanyId { get; init; }
    public Guid? BranchId { get; init; }
    public Guid? DepartmentId { get; init; }
    public Guid? PositionId { get; init; }
    public string EmployeeCode { get; init; } = string.Empty;
    public string FullName { get; init; } = string.Empty;
    public Gender? Gender { get; init; }
    public DateTime? BirthDate { get; init; }
    public string? IdentityNumber { get; init; }
    public DateTime? IdentityIssueDate { get; init; }
    public string? IdentityIssuePlace { get; init; }
    public string? Phone { get; init; }
    public string? Mobile { get; init; }
    public string? Email { get; init; }
    public string? PermanentAddress { get; init; }
    public string? CurrentAddress { get; init; }
    public string? Fax { get; init; }
    public string? LinkedIn { get; init; }
    public string? Skype { get; init; }
    public string? WeChat { get; init; }
    public DateTime? HireDate { get; init; }
    public DateTime? ResignDate { get; init; }
    public string? BankAccountNumber { get; init; }
    public string? BankName { get; init; }
    public string? BankBranch { get; init; }
    public string? PersonalTaxCode { get; init; }
    public string? SocialInsuranceNumber { get; init; }
    public bool IsActive { get; init; }
    public string? Notes { get; init; }
}

public class UpdateEmployeeCommandHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<UpdateEmployeeCommand, EmployeeDto>
{
    public async Task<EmployeeDto> Handle(
        UpdateEmployeeCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await context.Employees
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"Employee with Id '{request.Id}' not found.");

        entity.CompanyId = request.CompanyId;
        entity.BranchId = request.BranchId;
        entity.DepartmentId = request.DepartmentId;
        entity.PositionId = request.PositionId;
        entity.EmployeeCode = request.EmployeeCode;
        entity.FullName = request.FullName;
        entity.Gender = request.Gender;
        entity.BirthDate = request.BirthDate;
        entity.IdentityNumber = request.IdentityNumber;
        entity.IdentityIssueDate = request.IdentityIssueDate;
        entity.IdentityIssuePlace = request.IdentityIssuePlace;
        entity.Phone = request.Phone;
        entity.Mobile = request.Mobile;
        entity.Email = request.Email;
        entity.PermanentAddress = request.PermanentAddress;
        entity.CurrentAddress = request.CurrentAddress;
        entity.Fax = request.Fax;
        entity.LinkedIn = request.LinkedIn;
        entity.Skype = request.Skype;
        entity.WeChat = request.WeChat;
        entity.HireDate = request.HireDate;
        entity.ResignDate = request.ResignDate;
        entity.BankAccountNumber = request.BankAccountNumber;
        entity.BankName = request.BankName;
        entity.BankBranch = request.BankBranch;
        entity.PersonalTaxCode = request.PersonalTaxCode;
        entity.SocialInsuranceNumber = request.SocialInsuranceNumber;
        entity.IsActive = request.IsActive;
        entity.Notes = request.Notes;
        entity.ModifiedDate = DateTime.UtcNow;

        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<EmployeeDto>(entity);
    }
}

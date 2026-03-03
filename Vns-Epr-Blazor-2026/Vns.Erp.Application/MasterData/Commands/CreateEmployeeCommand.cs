using AutoMapper;
using MediatR;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;
using Vns.Erp.Domain.MasterData.Entities;
using Vns.Erp.Domain.MasterData.Enums;

namespace Vns.Erp.Application.MasterData.Commands;

public record CreateEmployeeCommand : IRequest<EmployeeDto>
{
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
    public string? BankAccountNumber { get; init; }
    public string? BankName { get; init; }
    public string? BankBranch { get; init; }
    public string? PersonalTaxCode { get; init; }
    public string? SocialInsuranceNumber { get; init; }
    public string? Notes { get; init; }
}

public class CreateEmployeeCommandHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<CreateEmployeeCommand, EmployeeDto>
{
    public async Task<EmployeeDto> Handle(
        CreateEmployeeCommand request,
        CancellationToken cancellationToken)
    {
        var entity = new Employee
        {
            CompanyId = request.CompanyId,
            BranchId = request.BranchId,
            DepartmentId = request.DepartmentId,
            PositionId = request.PositionId,
            EmployeeCode = request.EmployeeCode,
            FullName = request.FullName,
            Gender = request.Gender,
            BirthDate = request.BirthDate,
            IdentityNumber = request.IdentityNumber,
            IdentityIssueDate = request.IdentityIssueDate,
            IdentityIssuePlace = request.IdentityIssuePlace,
            Phone = request.Phone,
            Mobile = request.Mobile,
            Email = request.Email,
            PermanentAddress = request.PermanentAddress,
            CurrentAddress = request.CurrentAddress,
            Fax = request.Fax,
            LinkedIn = request.LinkedIn,
            Skype = request.Skype,
            WeChat = request.WeChat,
            HireDate = request.HireDate,
            BankAccountNumber = request.BankAccountNumber,
            BankName = request.BankName,
            BankBranch = request.BankBranch,
            PersonalTaxCode = request.PersonalTaxCode,
            SocialInsuranceNumber = request.SocialInsuranceNumber,
            Notes = request.Notes,
            IsActive = true
        };

        context.Employees.Add(entity);
        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<EmployeeDto>(entity);
    }
}

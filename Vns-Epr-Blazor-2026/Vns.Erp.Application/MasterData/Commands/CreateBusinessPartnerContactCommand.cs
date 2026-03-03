using AutoMapper;
using MediatR;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;
using Vns.Erp.Domain.MasterData.Entities;
using Vns.Erp.Domain.MasterData.Enums;

namespace Vns.Erp.Application.MasterData.Commands;

public record CreateBusinessPartnerContactCommand : IRequest<BusinessPartnerContactDto>
{
    public Guid SiteId { get; init; }
    public string FullName { get; init; } = string.Empty;
    public string? Position { get; init; }
    public string? Department { get; init; }
    public Gender? Gender { get; init; }
    public DateTime? BirthDate { get; init; }
    public string? Phone { get; init; }
    public string? Mobile { get; init; }
    public string? Email { get; init; }
    public string? Fax { get; init; }
    public string? LinkedIn { get; init; }
    public string? Skype { get; init; }
    public string? WeChat { get; init; }
    public bool IsPrimary { get; init; }
    public string? Notes { get; init; }
}

public class CreateBusinessPartnerContactCommandHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<CreateBusinessPartnerContactCommand, BusinessPartnerContactDto>
{
    public async Task<BusinessPartnerContactDto> Handle(
        CreateBusinessPartnerContactCommand request,
        CancellationToken cancellationToken)
    {
        var entity = new BusinessPartnerContact
        {
            SiteId = request.SiteId,
            FullName = request.FullName,
            Position = request.Position,
            Department = request.Department,
            Gender = request.Gender,
            BirthDate = request.BirthDate,
            Phone = request.Phone,
            Mobile = request.Mobile,
            Email = request.Email,
            Fax = request.Fax,
            LinkedIn = request.LinkedIn,
            Skype = request.Skype,
            WeChat = request.WeChat,
            IsPrimary = request.IsPrimary,
            Notes = request.Notes,
            IsActive = true
        };

        context.BusinessPartnerContacts.Add(entity);
        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<BusinessPartnerContactDto>(entity);
    }
}

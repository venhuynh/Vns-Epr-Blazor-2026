using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;
using Vns.Erp.Domain.MasterData.Enums;

namespace Vns.Erp.Application.MasterData.Commands;

public record UpdateBusinessPartnerContactCommand : IRequest<BusinessPartnerContactDto>
{
    public Guid Id { get; init; }
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
    public bool IsActive { get; init; }
    public string? Notes { get; init; }
}

public class UpdateBusinessPartnerContactCommandHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<UpdateBusinessPartnerContactCommand, BusinessPartnerContactDto>
{
    public async Task<BusinessPartnerContactDto> Handle(
        UpdateBusinessPartnerContactCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await context.BusinessPartnerContacts
            .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"BusinessPartnerContact with Id '{request.Id}' not found.");

        entity.SiteId = request.SiteId;
        entity.FullName = request.FullName;
        entity.Position = request.Position;
        entity.Department = request.Department;
        entity.Gender = request.Gender;
        entity.BirthDate = request.BirthDate;
        entity.Phone = request.Phone;
        entity.Mobile = request.Mobile;
        entity.Email = request.Email;
        entity.Fax = request.Fax;
        entity.LinkedIn = request.LinkedIn;
        entity.Skype = request.Skype;
        entity.WeChat = request.WeChat;
        entity.IsPrimary = request.IsPrimary;
        entity.IsActive = request.IsActive;
        entity.Notes = request.Notes;
        entity.ModifiedDate = DateTime.UtcNow;

        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<BusinessPartnerContactDto>(entity);
    }
}

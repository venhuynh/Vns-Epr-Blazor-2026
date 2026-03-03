using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;

namespace Vns.Erp.Application.MasterData.Commands;

public record UpdateBusinessPartnerCategoryCommand : IRequest<BusinessPartnerCategoryDto>
{
    public Guid Id { get; init; }
    public Guid? ParentCategoryId { get; init; }
    public string? CategoryCode { get; init; }
    public string CategoryName { get; init; } = string.Empty;
    public string? Description { get; init; }
    public int SortOrder { get; init; }
    public bool IsActive { get; init; }
}

public class UpdateBusinessPartnerCategoryCommandHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<UpdateBusinessPartnerCategoryCommand, BusinessPartnerCategoryDto>
{
    public async Task<BusinessPartnerCategoryDto> Handle(
        UpdateBusinessPartnerCategoryCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await context.BusinessPartnerCategories
            .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"BusinessPartnerCategory with Id '{request.Id}' not found.");

        entity.ParentCategoryId = request.ParentCategoryId;
        entity.CategoryCode = request.CategoryCode;
        entity.CategoryName = request.CategoryName;
        entity.Description = request.Description;
        entity.SortOrder = request.SortOrder;
        entity.IsActive = request.IsActive;
        entity.ModifiedDate = DateTime.UtcNow;

        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<BusinessPartnerCategoryDto>(entity);
    }
}

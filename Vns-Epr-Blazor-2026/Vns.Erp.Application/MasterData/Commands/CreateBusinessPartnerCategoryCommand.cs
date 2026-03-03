using AutoMapper;
using MediatR;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;
using Vns.Erp.Domain.MasterData.Entities;

namespace Vns.Erp.Application.MasterData.Commands;

public record CreateBusinessPartnerCategoryCommand : IRequest<BusinessPartnerCategoryDto>
{
    public Guid? ParentCategoryId { get; init; }
    public string? CategoryCode { get; init; }
    public string CategoryName { get; init; } = string.Empty;
    public string? Description { get; init; }
    public int SortOrder { get; init; }
}

public class CreateBusinessPartnerCategoryCommandHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<CreateBusinessPartnerCategoryCommand, BusinessPartnerCategoryDto>
{
    public async Task<BusinessPartnerCategoryDto> Handle(
        CreateBusinessPartnerCategoryCommand request,
        CancellationToken cancellationToken)
    {
        var entity = new BusinessPartnerCategory
        {
            ParentCategoryId = request.ParentCategoryId,
            CategoryCode = request.CategoryCode,
            CategoryName = request.CategoryName,
            Description = request.Description,
            SortOrder = request.SortOrder,
            IsActive = true
        };

        context.BusinessPartnerCategories.Add(entity);
        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<BusinessPartnerCategoryDto>(entity);
    }
}

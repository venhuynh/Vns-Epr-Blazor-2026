using AutoMapper;
using MediatR;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;
using Vns.Erp.Domain.MasterData.Entities;

namespace Vns.Erp.Application.MasterData.Commands;

public record CreateProductServiceCategoryCommand : IRequest<ProductServiceCategoryDto>
{
    public string? CategoryCode { get; init; }
    public string CategoryName { get; init; } = string.Empty;
    public string? Description { get; init; }
    public int SortOrder { get; init; }
    public Guid? ParentCategoryId { get; init; }
}

public class CreateProductServiceCategoryCommandHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<CreateProductServiceCategoryCommand, ProductServiceCategoryDto>
{
    public async Task<ProductServiceCategoryDto> Handle(
        CreateProductServiceCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = new ProductServiceCategory
        {
            CategoryCode = request.CategoryCode,
            CategoryName = request.CategoryName,
            Description = request.Description,
            SortOrder = request.SortOrder,
            ParentCategoryId = request.ParentCategoryId,
            IsActive = true
        };

        context.ProductServiceCategories.Add(entity);
        await context.SaveChangesAsync(cancellationToken);
        return mapper.Map<ProductServiceCategoryDto>(entity);
    }
}

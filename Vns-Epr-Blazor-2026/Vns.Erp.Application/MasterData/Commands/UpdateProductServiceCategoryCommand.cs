using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;

namespace Vns.Erp.Application.MasterData.Commands;

public record UpdateProductServiceCategoryCommand : IRequest<ProductServiceCategoryDto>
{
    public Guid Id { get; init; }
    public string? CategoryCode { get; init; }
    public string CategoryName { get; init; } = string.Empty;
    public string? Description { get; init; }
    public int SortOrder { get; init; }
    public bool IsActive { get; init; }
    public Guid? ParentCategoryId { get; init; }
}

public class UpdateProductServiceCategoryCommandHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<UpdateProductServiceCategoryCommand, ProductServiceCategoryDto>
{
    public async Task<ProductServiceCategoryDto> Handle(
        UpdateProductServiceCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.ProductServiceCategories
            .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"ProductServiceCategory with Id '{request.Id}' not found.");

        entity.CategoryCode = request.CategoryCode;
        entity.CategoryName = request.CategoryName;
        entity.Description = request.Description;
        entity.SortOrder = request.SortOrder;
        entity.IsActive = request.IsActive;
        entity.ParentCategoryId = request.ParentCategoryId;
        entity.ModifiedDate = DateTime.UtcNow;

        await context.SaveChangesAsync(cancellationToken);
        return mapper.Map<ProductServiceCategoryDto>(entity);
    }
}

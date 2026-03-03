using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;

namespace Vns.Erp.Application.MasterData.Commands;

public record UpdateProductServiceCommand : IRequest<ProductServiceDto>
{
    public Guid Id { get; init; }
    public string ProductCode { get; init; } = string.Empty;
    public string ProductName { get; init; } = string.Empty;
    public bool IsService { get; init; }
    public string? Description { get; init; }
    public bool IsActive { get; init; }
    public Guid? CategoryId { get; init; }
}

public class UpdateProductServiceCommandHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<UpdateProductServiceCommand, ProductServiceDto>
{
    public async Task<ProductServiceDto> Handle(
        UpdateProductServiceCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.ProductServices
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"ProductService with Id '{request.Id}' not found.");

        entity.ProductCode = request.ProductCode;
        entity.ProductName = request.ProductName;
        entity.IsService = request.IsService;
        entity.Description = request.Description;
        entity.IsActive = request.IsActive;
        entity.CategoryId = request.CategoryId;
        entity.ModifiedDate = DateTime.UtcNow;

        await context.SaveChangesAsync(cancellationToken);
        return mapper.Map<ProductServiceDto>(entity);
    }
}

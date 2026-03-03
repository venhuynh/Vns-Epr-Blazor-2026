using AutoMapper;
using MediatR;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;
using Vns.Erp.Domain.MasterData.Entities;

namespace Vns.Erp.Application.MasterData.Commands;

public record CreateProductServiceCommand : IRequest<ProductServiceDto>
{
    public string ProductCode { get; init; } = string.Empty;
    public string ProductName { get; init; } = string.Empty;
    public bool IsService { get; init; }
    public string? Description { get; init; }
    public Guid? CategoryId { get; init; }
}

public class CreateProductServiceCommandHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<CreateProductServiceCommand, ProductServiceDto>
{
    public async Task<ProductServiceDto> Handle(
        CreateProductServiceCommand request, CancellationToken cancellationToken)
    {
        var entity = new ProductService
        {
            ProductCode = request.ProductCode,
            ProductName = request.ProductName,
            IsService = request.IsService,
            Description = request.Description,
            CategoryId = request.CategoryId,
            IsActive = true
        };

        context.ProductServices.Add(entity);
        await context.SaveChangesAsync(cancellationToken);
        return mapper.Map<ProductServiceDto>(entity);
    }
}

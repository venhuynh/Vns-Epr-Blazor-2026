using AutoMapper;
using MediatR;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;
using Vns.Erp.Domain.MasterData.Entities;

namespace Vns.Erp.Application.MasterData.Commands;

public record CreateProductAttributeCommand : IRequest<ProductAttributeDto>
{
    public string AttributeName { get; init; } = string.Empty;
    public string DataType { get; init; } = string.Empty;
    public string? Description { get; init; }
}

public class CreateProductAttributeCommandHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<CreateProductAttributeCommand, ProductAttributeDto>
{
    public async Task<ProductAttributeDto> Handle(
        CreateProductAttributeCommand request, CancellationToken cancellationToken)
    {
        var entity = new ProductAttribute
        {
            AttributeName = request.AttributeName,
            DataType = request.DataType,
            Description = request.Description
        };

        context.ProductAttributes.Add(entity);
        await context.SaveChangesAsync(cancellationToken);
        return mapper.Map<ProductAttributeDto>(entity);
    }
}

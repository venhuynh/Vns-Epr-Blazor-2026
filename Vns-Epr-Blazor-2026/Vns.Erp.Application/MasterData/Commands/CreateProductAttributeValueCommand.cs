using AutoMapper;
using MediatR;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;
using Vns.Erp.Domain.MasterData.Entities;

namespace Vns.Erp.Application.MasterData.Commands;

public record CreateProductAttributeValueCommand : IRequest<ProductAttributeValueDto>
{
    public Guid? ProductAttributeId { get; init; }
    public string Value { get; init; } = string.Empty;
}

public class CreateProductAttributeValueCommandHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<CreateProductAttributeValueCommand, ProductAttributeValueDto>
{
    public async Task<ProductAttributeValueDto> Handle(
        CreateProductAttributeValueCommand request, CancellationToken cancellationToken)
    {
        var entity = new ProductAttributeValue
        {
            ProductAttributeId = request.ProductAttributeId,
            Value = request.Value
        };

        context.ProductAttributeValues.Add(entity);
        await context.SaveChangesAsync(cancellationToken);
        return mapper.Map<ProductAttributeValueDto>(entity);
    }
}

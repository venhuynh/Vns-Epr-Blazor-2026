using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;

namespace Vns.Erp.Application.MasterData.Commands;

public record UpdateProductAttributeValueCommand : IRequest<ProductAttributeValueDto>
{
    public Guid Id { get; init; }
    public Guid? ProductAttributeId { get; init; }
    public string Value { get; init; } = string.Empty;
}

public class UpdateProductAttributeValueCommandHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<UpdateProductAttributeValueCommand, ProductAttributeValueDto>
{
    public async Task<ProductAttributeValueDto> Handle(
        UpdateProductAttributeValueCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.ProductAttributeValues
            .FirstOrDefaultAsync(v => v.Id == request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"ProductAttributeValue with Id '{request.Id}' not found.");

        entity.ProductAttributeId = request.ProductAttributeId;
        entity.Value = request.Value;
        entity.ModifiedDate = DateTime.UtcNow;

        await context.SaveChangesAsync(cancellationToken);
        return mapper.Map<ProductAttributeValueDto>(entity);
    }
}

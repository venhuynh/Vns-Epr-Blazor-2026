using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;

namespace Vns.Erp.Application.MasterData.Commands;

public record UpdateProductAttributeCommand : IRequest<ProductAttributeDto>
{
    public Guid Id { get; init; }
    public string AttributeName { get; init; } = string.Empty;
    public string DataType { get; init; } = string.Empty;
    public string? Description { get; init; }
}

public class UpdateProductAttributeCommandHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<UpdateProductAttributeCommand, ProductAttributeDto>
{
    public async Task<ProductAttributeDto> Handle(
        UpdateProductAttributeCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.ProductAttributes
            .FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"ProductAttribute with Id '{request.Id}' not found.");

        entity.AttributeName = request.AttributeName;
        entity.DataType = request.DataType;
        entity.Description = request.Description;
        entity.ModifiedDate = DateTime.UtcNow;

        await context.SaveChangesAsync(cancellationToken);
        return mapper.Map<ProductAttributeDto>(entity);
    }
}

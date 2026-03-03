using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;

namespace Vns.Erp.Application.MasterData.Commands;

public record UpdateVariantAttributeLinkCommand : IRequest<VariantAttributeLinkDto>
{
    public Guid Id { get; init; }
    public Guid? ProductVariantId { get; init; }
    public Guid? ProductAttributeId { get; init; }
    public Guid? ProductAttributeValueId { get; init; }
}

public class UpdateVariantAttributeLinkCommandHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<UpdateVariantAttributeLinkCommand, VariantAttributeLinkDto>
{
    public async Task<VariantAttributeLinkDto> Handle(
        UpdateVariantAttributeLinkCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.VariantAttributeLinks
            .FirstOrDefaultAsync(l => l.Id == request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"VariantAttributeLink with Id '{request.Id}' not found.");

        entity.ProductVariantId = request.ProductVariantId;
        entity.ProductAttributeId = request.ProductAttributeId;
        entity.ProductAttributeValueId = request.ProductAttributeValueId;
        entity.ModifiedDate = DateTime.UtcNow;

        await context.SaveChangesAsync(cancellationToken);
        return mapper.Map<VariantAttributeLinkDto>(entity);
    }
}

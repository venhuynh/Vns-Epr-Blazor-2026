using AutoMapper;
using MediatR;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;
using Vns.Erp.Domain.MasterData.Entities;

namespace Vns.Erp.Application.MasterData.Commands;

public record CreateVariantAttributeLinkCommand : IRequest<VariantAttributeLinkDto>
{
    public Guid? ProductVariantId { get; init; }
    public Guid? ProductAttributeId { get; init; }
    public Guid? ProductAttributeValueId { get; init; }
}

public class CreateVariantAttributeLinkCommandHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<CreateVariantAttributeLinkCommand, VariantAttributeLinkDto>
{
    public async Task<VariantAttributeLinkDto> Handle(
        CreateVariantAttributeLinkCommand request, CancellationToken cancellationToken)
    {
        var entity = new VariantAttributeLink
        {
            ProductVariantId = request.ProductVariantId,
            ProductAttributeId = request.ProductAttributeId,
            ProductAttributeValueId = request.ProductAttributeValueId
        };

        context.VariantAttributeLinks.Add(entity);
        await context.SaveChangesAsync(cancellationToken);
        return mapper.Map<VariantAttributeLinkDto>(entity);
    }
}

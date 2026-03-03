using AutoMapper;
using MediatR;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;
using Vns.Erp.Domain.MasterData.Entities;

namespace Vns.Erp.Application.MasterData.Commands;

public record CreateProductVariantCommand : IRequest<ProductVariantDto>
{
    public Guid? ProductId { get; init; }
    public string VariantCode { get; init; } = string.Empty;
    public string? VariantFullName { get; init; }
    public string? VariantNameForReport { get; init; }
    public Guid? UnitId { get; init; }
}

public class CreateProductVariantCommandHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<CreateProductVariantCommand, ProductVariantDto>
{
    public async Task<ProductVariantDto> Handle(
        CreateProductVariantCommand request, CancellationToken cancellationToken)
    {
        var entity = new ProductVariant
        {
            ProductId = request.ProductId,
            VariantCode = request.VariantCode,
            VariantFullName = request.VariantFullName,
            VariantNameForReport = request.VariantNameForReport,
            UnitId = request.UnitId,
            IsActive = true
        };

        context.ProductVariants.Add(entity);
        await context.SaveChangesAsync(cancellationToken);
        return mapper.Map<ProductVariantDto>(entity);
    }
}

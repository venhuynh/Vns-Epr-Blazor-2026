using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;

namespace Vns.Erp.Application.MasterData.Commands;

public record UpdateProductVariantCommand : IRequest<ProductVariantDto>
{
    public Guid Id { get; init; }
    public Guid? ProductId { get; init; }
    public string VariantCode { get; init; } = string.Empty;
    public string? VariantFullName { get; init; }
    public string? VariantNameForReport { get; init; }
    public bool IsActive { get; init; }
    public Guid? UnitId { get; init; }
}

public class UpdateProductVariantCommandHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<UpdateProductVariantCommand, ProductVariantDto>
{
    public async Task<ProductVariantDto> Handle(
        UpdateProductVariantCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.ProductVariants
            .FirstOrDefaultAsync(v => v.Id == request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"ProductVariant with Id '{request.Id}' not found.");

        entity.ProductId = request.ProductId;
        entity.VariantCode = request.VariantCode;
        entity.VariantFullName = request.VariantFullName;
        entity.VariantNameForReport = request.VariantNameForReport;
        entity.IsActive = request.IsActive;
        entity.UnitId = request.UnitId;
        entity.ModifiedDate = DateTime.UtcNow;

        await context.SaveChangesAsync(cancellationToken);
        return mapper.Map<ProductVariantDto>(entity);
    }
}

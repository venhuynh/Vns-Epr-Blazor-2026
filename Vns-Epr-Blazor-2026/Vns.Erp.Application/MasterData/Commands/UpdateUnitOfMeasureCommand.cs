using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;

namespace Vns.Erp.Application.MasterData.Commands;

/// <summary>
/// Updates an existing UnitOfMeasure entity.
/// </summary>
public record UpdateUnitOfMeasureCommand : IRequest<UnitOfMeasureDto>
{
    public Guid Id { get; init; }
    public string UnitCode { get; init; } = string.Empty;
    public string UnitName { get; init; } = string.Empty;
    public string? Description { get; init; }
    public bool IsActive { get; init; }
}

public class UpdateUnitOfMeasureCommandHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<UpdateUnitOfMeasureCommand, UnitOfMeasureDto>
{
    public async Task<UnitOfMeasureDto> Handle(
        UpdateUnitOfMeasureCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await context.UnitsOfMeasure
            .FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"UnitOfMeasure with Id '{request.Id}' not found.");

        entity.UnitCode = request.UnitCode;
        entity.UnitName = request.UnitName;
        entity.Description = request.Description;
        entity.IsActive = request.IsActive;
        entity.ModifiedDate = DateTime.UtcNow;

        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<UnitOfMeasureDto>(entity);
    }
}

using AutoMapper;
using MediatR;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;
using Vns.Erp.Domain.MasterData.Entities;

namespace Vns.Erp.Application.MasterData.Commands;

/// <summary>
/// Creates a new UnitOfMeasure entity.
/// </summary>
public record CreateUnitOfMeasureCommand : IRequest<UnitOfMeasureDto>
{
    public string UnitCode { get; init; } = string.Empty;
    public string UnitName { get; init; } = string.Empty;
    public string? Description { get; init; }
}

public class CreateUnitOfMeasureCommandHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<CreateUnitOfMeasureCommand, UnitOfMeasureDto>
{
    public async Task<UnitOfMeasureDto> Handle(
        CreateUnitOfMeasureCommand request,
        CancellationToken cancellationToken)
    {
        var entity = new UnitOfMeasure
        {
            UnitCode = request.UnitCode,
            UnitName = request.UnitName,
            Description = request.Description,
            IsActive = true
        };

        context.UnitsOfMeasure.Add(entity);
        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<UnitOfMeasureDto>(entity);
    }
}

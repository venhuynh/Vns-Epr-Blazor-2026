using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;

namespace Vns.Erp.Application.MasterData.Commands;

public record UpdatePositionCommand : IRequest<PositionDto>
{
    public Guid Id { get; init; }
    public Guid CompanyId { get; init; }
    public string PositionCode { get; init; } = string.Empty;
    public string PositionName { get; init; } = string.Empty;
    public string? Description { get; init; }
    public bool IsManagerLevel { get; init; }
    public int SortOrder { get; init; }
    public bool IsActive { get; init; }
}

public class UpdatePositionCommandHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<UpdatePositionCommand, PositionDto>
{
    public async Task<PositionDto> Handle(
        UpdatePositionCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await context.Positions
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"Position with Id '{request.Id}' not found.");

        entity.CompanyId = request.CompanyId;
        entity.PositionCode = request.PositionCode;
        entity.PositionName = request.PositionName;
        entity.Description = request.Description;
        entity.IsManagerLevel = request.IsManagerLevel;
        entity.SortOrder = request.SortOrder;
        entity.IsActive = request.IsActive;
        entity.ModifiedDate = DateTime.UtcNow;

        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<PositionDto>(entity);
    }
}

using AutoMapper;
using MediatR;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Application.MasterData.DTOs;
using Vns.Erp.Domain.MasterData.Entities;

namespace Vns.Erp.Application.MasterData.Commands;

public record CreatePositionCommand : IRequest<PositionDto>
{
    public Guid CompanyId { get; init; }
    public string PositionCode { get; init; } = string.Empty;
    public string PositionName { get; init; } = string.Empty;
    public string? Description { get; init; }
    public bool IsManagerLevel { get; init; }
    public int SortOrder { get; init; }
}

public class CreatePositionCommandHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<CreatePositionCommand, PositionDto>
{
    public async Task<PositionDto> Handle(
        CreatePositionCommand request,
        CancellationToken cancellationToken)
    {
        var entity = new Position
        {
            CompanyId = request.CompanyId,
            PositionCode = request.PositionCode,
            PositionName = request.PositionName,
            Description = request.Description,
            IsManagerLevel = request.IsManagerLevel,
            SortOrder = request.SortOrder,
            IsActive = true
        };

        context.Positions.Add(entity);
        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<PositionDto>(entity);
    }
}

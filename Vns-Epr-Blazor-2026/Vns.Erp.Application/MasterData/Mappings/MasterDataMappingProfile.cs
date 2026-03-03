using AutoMapper;
using Vns.Erp.Domain.MasterData.Entities;
using Vns.Erp.Application.MasterData.DTOs;

namespace Vns.Erp.Application.MasterData.Mappings;

/// <summary>
/// AutoMapper profile for Master Data entity ↔ DTO mappings.
/// </summary>
public class MasterDataMappingProfile : Profile
{
    public MasterDataMappingProfile()
    {
        CreateMap<Company, CompanyDto>().ReverseMap();
        CreateMap<UnitOfMeasure, UnitOfMeasureDto>().ReverseMap();
    }
}

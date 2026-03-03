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
        // Company group
        CreateMap<Company, CompanyDto>().ReverseMap();
        CreateMap<CompanyBranch, CompanyBranchDto>().ReverseMap();
        CreateMap<Department, DepartmentDto>().ReverseMap();
        CreateMap<Employee, EmployeeDto>().ReverseMap();
        CreateMap<Position, PositionDto>().ReverseMap();

        // Lookup
        CreateMap<UnitOfMeasure, UnitOfMeasureDto>().ReverseMap();
    }
}

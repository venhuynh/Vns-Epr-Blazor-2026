using AutoMapper;
using Vns.Erp.Domain.MasterData.Entities;
using Vns.Erp.Application.MasterData.DTOs;

namespace Vns.Erp.Application.MasterData.Mappings;

/// <summary>
/// AutoMapper profile for all Master Data entity ↔ DTO mappings.
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

        // Partner group
        CreateMap<BusinessPartner, BusinessPartnerDto>().ReverseMap();
        CreateMap<BusinessPartnerCategory, BusinessPartnerCategoryDto>().ReverseMap();
        CreateMap<BusinessPartnerContact, BusinessPartnerContactDto>().ReverseMap();
        CreateMap<BusinessPartnerSite, BusinessPartnerSiteDto>().ReverseMap();

        // Product/Service group
        CreateMap<ProductService, ProductServiceDto>().ReverseMap();
        CreateMap<ProductServiceCategory, ProductServiceCategoryDto>().ReverseMap();
        CreateMap<UnitOfMeasure, UnitOfMeasureDto>().ReverseMap();
        CreateMap<ProductAttribute, ProductAttributeDto>().ReverseMap();
        CreateMap<ProductAttributeValue, ProductAttributeValueDto>().ReverseMap();
        CreateMap<ProductVariant, ProductVariantDto>().ReverseMap();
        CreateMap<VariantAttributeLink, VariantAttributeLinkDto>().ReverseMap();
    }
}

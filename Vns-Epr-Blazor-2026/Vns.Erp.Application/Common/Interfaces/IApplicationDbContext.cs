using Microsoft.EntityFrameworkCore;
using Vns.Erp.Domain.Identity;
using Vns.Erp.Domain.MasterData.Entities;

namespace Vns.Erp.Application.Common.Interfaces;

/// <summary>
/// Abstraction for the application database context.
/// Implemented in Infrastructure layer.
/// </summary>
public interface IApplicationDbContext
{
    // === Identity ===
    DbSet<ApplicationUser> Users { get; }

    // === Master Data — Company ===
    DbSet<Company> Companies { get; }
    DbSet<CompanyBranch> CompanyBranches { get; }
    DbSet<Department> Departments { get; }
    DbSet<Employee> Employees { get; }
    DbSet<Position> Positions { get; }

    // === Master Data — Partner ===
    DbSet<BusinessPartner> BusinessPartners { get; }
    DbSet<BusinessPartnerCategory> BusinessPartnerCategories { get; }
    DbSet<BusinessPartnerContact> BusinessPartnerContacts { get; }
    DbSet<BusinessPartnerSite> BusinessPartnerSites { get; }

    // === Master Data — Product/Service ===
    DbSet<ProductService> ProductServices { get; }
    DbSet<ProductServiceCategory> ProductServiceCategories { get; }
    DbSet<UnitOfMeasure> UnitsOfMeasure { get; }
    DbSet<ProductAttribute> ProductAttributes { get; }
    DbSet<ProductAttributeValue> ProductAttributeValues { get; }
    DbSet<ProductVariant> ProductVariants { get; }
    DbSet<VariantAttributeLink> VariantAttributeLinks { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

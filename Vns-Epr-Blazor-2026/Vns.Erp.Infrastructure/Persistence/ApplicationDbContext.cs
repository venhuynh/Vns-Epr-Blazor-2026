using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vns.Erp.Application.Common.Interfaces;
using Vns.Erp.Domain.Identity;
using Vns.Erp.Domain.MasterData.Entities;

namespace Vns.Erp.Infrastructure.Persistence;

/// <summary>
/// Application database context with Identity support.
/// Implements IApplicationDbContext from the Application layer.
/// </summary>
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser, ApplicationRole, string>(options), IApplicationDbContext
{
    // === Master Data — Company ===
    public DbSet<Company> Companies => Set<Company>();
    public DbSet<CompanyBranch> CompanyBranches => Set<CompanyBranch>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Position> Positions => Set<Position>();

    // === Master Data — Partner ===
    public DbSet<BusinessPartner> BusinessPartners => Set<BusinessPartner>();
    public DbSet<BusinessPartnerCategory> BusinessPartnerCategories => Set<BusinessPartnerCategory>();
    public DbSet<BusinessPartnerContact> BusinessPartnerContacts => Set<BusinessPartnerContact>();
    public DbSet<BusinessPartnerSite> BusinessPartnerSites => Set<BusinessPartnerSite>();

    // === Master Data — Product/Service ===
    public DbSet<ProductService> ProductServices => Set<ProductService>();
    public DbSet<ProductServiceCategory> ProductServiceCategories => Set<ProductServiceCategory>();
    public DbSet<UnitOfMeasure> UnitsOfMeasure => Set<UnitOfMeasure>();
    public DbSet<ProductAttribute> ProductAttributes => Set<ProductAttribute>();
    public DbSet<ProductAttributeValue> ProductAttributeValues => Set<ProductAttributeValue>();
    public DbSet<ProductVariant> ProductVariants => Set<ProductVariant>();
    public DbSet<VariantAttributeLink> VariantAttributeLinks => Set<VariantAttributeLink>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Apply all entity configurations from this assembly
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}

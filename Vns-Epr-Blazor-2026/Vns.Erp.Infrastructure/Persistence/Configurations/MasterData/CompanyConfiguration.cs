using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vns.Erp.Domain.MasterData.Entities;

namespace Vns.Erp.Infrastructure.Persistence.Configurations.MasterData;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Companies");

        // === Primary Key ===
        builder.HasKey(c => c.Id);

        // === Scalar properties ===
        builder.Property(c => c.CompanyCode).IsRequired().HasMaxLength(50);
        builder.Property(c => c.CompanyName).IsRequired().HasMaxLength(200);
        builder.Property(c => c.ShortName).HasMaxLength(100);
        builder.Property(c => c.TaxCode).HasMaxLength(50);
        builder.Property(c => c.RepresentativeName).HasMaxLength(200);
        builder.Property(c => c.RepresentativeTitle).HasMaxLength(100);
        builder.Property(c => c.Phone).HasMaxLength(50);
        builder.Property(c => c.Fax).HasMaxLength(50);
        builder.Property(c => c.Email).HasMaxLength(200);
        builder.Property(c => c.Website).HasMaxLength(500);
        builder.Property(c => c.Address).HasMaxLength(500);
        builder.Property(c => c.City).HasMaxLength(100);
        builder.Property(c => c.Country).HasMaxLength(100);
        builder.Property(c => c.Notes).HasMaxLength(2000);

        // === Audit fields ===
        builder.Property(c => c.CreatedBy).HasMaxLength(200);
        builder.Property(c => c.ModifiedBy).HasMaxLength(200);

        // === Index ===
        builder.HasIndex(c => c.CompanyCode).IsUnique();
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vns.Erp.Domain.MasterData.Entities;

namespace Vns.Erp.Infrastructure.Persistence.Configurations.MasterData;

public class BusinessPartnerConfiguration : IEntityTypeConfiguration<BusinessPartner>
{
    public void Configure(EntityTypeBuilder<BusinessPartner> builder)
    {
        builder.ToTable("BusinessPartners");

        builder.HasKey(p => p.Id);

        // === Scalar properties ===
        builder.Property(p => p.PartnerCode).IsRequired().HasMaxLength(50);
        builder.Property(p => p.PartnerName).IsRequired().HasMaxLength(200);
        builder.Property(p => p.TaxCode).HasMaxLength(50);
        builder.Property(p => p.Phone).HasMaxLength(50);
        builder.Property(p => p.Email).HasMaxLength(200);
        builder.Property(p => p.Website).HasMaxLength(500);
        builder.Property(p => p.Address).HasMaxLength(500);
        builder.Property(p => p.City).HasMaxLength(100);
        builder.Property(p => p.Country).HasMaxLength(100);
        builder.Property(p => p.Notes).HasMaxLength(2000);
        builder.Property(p => p.CreatedBy).HasMaxLength(200);
        builder.Property(p => p.ModifiedBy).HasMaxLength(200);

        // === Enum conversion ===
        builder.Property(p => p.PartnerType)
            .HasConversion<string>()
            .HasMaxLength(20);

        // === Indexes ===
        builder.HasIndex(p => p.PartnerCode).IsUnique();
        builder.HasIndex(p => p.TaxCode);
    }
}

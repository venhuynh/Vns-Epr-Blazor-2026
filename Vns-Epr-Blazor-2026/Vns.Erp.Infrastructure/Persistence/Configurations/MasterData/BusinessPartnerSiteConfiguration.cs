using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vns.Erp.Domain.MasterData.Entities;

namespace Vns.Erp.Infrastructure.Persistence.Configurations.MasterData;

public class BusinessPartnerSiteConfiguration : IEntityTypeConfiguration<BusinessPartnerSite>
{
    public void Configure(EntityTypeBuilder<BusinessPartnerSite> builder)
    {
        builder.ToTable("BusinessPartnerSites");

        builder.HasKey(s => s.Id);

        // === Scalar properties ===
        builder.Property(s => s.SiteCode).IsRequired().HasMaxLength(50);
        builder.Property(s => s.SiteName).IsRequired().HasMaxLength(200);
        builder.Property(s => s.Address).HasMaxLength(500);
        builder.Property(s => s.District).HasMaxLength(100);
        builder.Property(s => s.City).HasMaxLength(100);
        builder.Property(s => s.Province).HasMaxLength(100);
        builder.Property(s => s.Country).HasMaxLength(100);
        builder.Property(s => s.PostalCode).HasMaxLength(20);
        builder.Property(s => s.Phone).HasMaxLength(50);
        builder.Property(s => s.Email).HasMaxLength(200);
        builder.Property(s => s.GoogleMapUrl).HasMaxLength(1000);
        builder.Property(s => s.Notes).HasMaxLength(2000);
        builder.Property(s => s.CreatedBy).HasMaxLength(200);
        builder.Property(s => s.ModifiedBy).HasMaxLength(200);

        // === Enum conversion ===
        builder.Property(s => s.SiteType)
            .HasConversion<string>()
            .HasMaxLength(20);

        // === FK: BusinessPartner (required) ===
        builder.HasOne(s => s.Partner)
            .WithMany(p => p.Sites)
            .HasForeignKey(s => s.PartnerId)
            .OnDelete(DeleteBehavior.Restrict);

        // === Indexes ===
        builder.HasIndex(s => new { s.PartnerId, s.SiteCode }).IsUnique();
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vns.Erp.Domain.MasterData.Entities;

namespace Vns.Erp.Infrastructure.Persistence.Configurations.MasterData;

public class BusinessPartnerContactConfiguration : IEntityTypeConfiguration<BusinessPartnerContact>
{
    public void Configure(EntityTypeBuilder<BusinessPartnerContact> builder)
    {
        builder.ToTable("BusinessPartnerContacts");

        builder.HasKey(c => c.Id);

        // === Scalar — Identity ===
        builder.Property(c => c.FullName).IsRequired().HasMaxLength(200);
        builder.Property(c => c.Position).HasMaxLength(200);
        builder.Property(c => c.Department).HasMaxLength(200);

        // === Scalar — Contact ===
        builder.Property(c => c.Phone).HasMaxLength(50);
        builder.Property(c => c.Mobile).HasMaxLength(50);
        builder.Property(c => c.Email).HasMaxLength(200);
        builder.Property(c => c.Fax).HasMaxLength(50);

        // === Scalar — Social ===
        builder.Property(c => c.LinkedIn).HasMaxLength(200);
        builder.Property(c => c.Skype).HasMaxLength(100);
        builder.Property(c => c.WeChat).HasMaxLength(100);

        // === Scalar — System ===
        builder.Property(c => c.Notes).HasMaxLength(2000);
        builder.Property(c => c.CreatedBy).HasMaxLength(200);
        builder.Property(c => c.ModifiedBy).HasMaxLength(200);

        // === Enum conversion ===
        builder.Property(c => c.Gender)
            .HasConversion<string>()
            .HasMaxLength(10);

        // === FK: BusinessPartnerSite (required) ===
        builder.HasOne(c => c.Site)
            .WithMany(s => s.Contacts)
            .HasForeignKey(c => c.SiteId)
            .OnDelete(DeleteBehavior.Restrict);

        // === Indexes ===
        builder.HasIndex(c => c.SiteId);
        builder.HasIndex(c => c.Email);
    }
}

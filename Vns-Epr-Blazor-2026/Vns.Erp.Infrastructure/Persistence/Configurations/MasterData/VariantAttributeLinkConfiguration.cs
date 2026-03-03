using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vns.Erp.Domain.MasterData.Entities;

namespace Vns.Erp.Infrastructure.Persistence.Configurations.MasterData;

public class VariantAttributeLinkConfiguration : IEntityTypeConfiguration<VariantAttributeLink>
{
    public void Configure(EntityTypeBuilder<VariantAttributeLink> builder)
    {
        builder.ToTable("VariantAttributeLinks");

        builder.HasKey(l => l.Id);

        // === Audit fields ===
        builder.Property(l => l.CreatedBy).HasMaxLength(200);
        builder.Property(l => l.ModifiedBy).HasMaxLength(200);

        // === FK: ProductVariant (optional) ===
        builder.HasOne(l => l.Variant)
            .WithMany(v => v.AttributeLinks)
            .HasForeignKey(l => l.ProductVariantId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        // === FK: ProductAttribute (optional, no inverse nav) ===
        builder.HasOne(l => l.Attribute)
            .WithMany()
            .HasForeignKey(l => l.ProductAttributeId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        // === FK: ProductAttributeValue (optional, no inverse nav) ===
        builder.HasOne(l => l.AttributeValue)
            .WithMany()
            .HasForeignKey(l => l.ProductAttributeValueId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        // === Indexes: prevent duplicate links ===
        builder.HasIndex(l => new { l.ProductVariantId, l.ProductAttributeId, l.ProductAttributeValueId }).IsUnique();
    }
}

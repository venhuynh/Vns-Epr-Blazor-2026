using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vns.Erp.Domain.MasterData.Entities;

namespace Vns.Erp.Infrastructure.Persistence.Configurations.MasterData;

public class ProductAttributeValueConfiguration : IEntityTypeConfiguration<ProductAttributeValue>
{
    public void Configure(EntityTypeBuilder<ProductAttributeValue> builder)
    {
        builder.ToTable("ProductAttributeValues");

        builder.HasKey(v => v.Id);

        // === Scalar properties ===
        builder.Property(v => v.Value).IsRequired().HasMaxLength(200);
        builder.Property(v => v.CreatedBy).HasMaxLength(200);
        builder.Property(v => v.ModifiedBy).HasMaxLength(200);

        // === FK: ProductAttribute (optional) ===
        builder.HasOne(v => v.Attribute)
            .WithMany(a => a.Values)
            .HasForeignKey(v => v.ProductAttributeId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        // === Indexes ===
        builder.HasIndex(v => new { v.ProductAttributeId, v.Value }).IsUnique();
    }
}

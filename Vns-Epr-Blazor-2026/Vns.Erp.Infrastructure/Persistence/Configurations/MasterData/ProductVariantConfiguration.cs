using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vns.Erp.Domain.MasterData.Entities;

namespace Vns.Erp.Infrastructure.Persistence.Configurations.MasterData;

public class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
{
    public void Configure(EntityTypeBuilder<ProductVariant> builder)
    {
        builder.ToTable("ProductVariants");

        builder.HasKey(v => v.Id);

        // === Scalar properties ===
        builder.Property(v => v.VariantCode).IsRequired().HasMaxLength(50);
        builder.Property(v => v.VariantFullName).HasMaxLength(500);
        builder.Property(v => v.VariantNameForReport).HasMaxLength(200);
        builder.Property(v => v.CreatedBy).HasMaxLength(200);
        builder.Property(v => v.ModifiedBy).HasMaxLength(200);

        // === FK: ProductService (optional) ===
        builder.HasOne(v => v.Product)
            .WithMany(p => p.Variants)
            .HasForeignKey(v => v.ProductId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        // === FK: UnitOfMeasure (optional) ===
        builder.HasOne(v => v.Unit)
            .WithMany(u => u.ProductVariants)
            .HasForeignKey(v => v.UnitId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        // === Indexes ===
        builder.HasIndex(v => v.VariantCode).IsUnique();
    }
}

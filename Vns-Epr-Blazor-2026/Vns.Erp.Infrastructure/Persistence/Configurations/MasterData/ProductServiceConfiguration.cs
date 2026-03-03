using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vns.Erp.Domain.MasterData.Entities;

namespace Vns.Erp.Infrastructure.Persistence.Configurations.MasterData;

public class ProductServiceConfiguration : IEntityTypeConfiguration<ProductService>
{
    public void Configure(EntityTypeBuilder<ProductService> builder)
    {
        builder.ToTable("ProductServices");

        builder.HasKey(p => p.Id);

        // === Scalar properties ===
        builder.Property(p => p.ProductCode).IsRequired().HasMaxLength(50);
        builder.Property(p => p.ProductName).IsRequired().HasMaxLength(200);
        builder.Property(p => p.Description).HasMaxLength(2000);
        builder.Property(p => p.CreatedBy).HasMaxLength(200);
        builder.Property(p => p.ModifiedBy).HasMaxLength(200);

        // === FK: ProductServiceCategory (optional) ===
        builder.HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        // === Indexes ===
        builder.HasIndex(p => p.ProductCode).IsUnique();
    }
}

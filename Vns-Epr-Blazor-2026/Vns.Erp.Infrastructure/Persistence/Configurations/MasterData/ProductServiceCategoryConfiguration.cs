using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vns.Erp.Domain.MasterData.Entities;

namespace Vns.Erp.Infrastructure.Persistence.Configurations.MasterData;

public class ProductServiceCategoryConfiguration : IEntityTypeConfiguration<ProductServiceCategory>
{
    public void Configure(EntityTypeBuilder<ProductServiceCategory> builder)
    {
        builder.ToTable("ProductServiceCategories");

        builder.HasKey(c => c.Id);

        // === Scalar properties ===
        builder.Property(c => c.CategoryCode).HasMaxLength(50);
        builder.Property(c => c.CategoryName).IsRequired().HasMaxLength(200);
        builder.Property(c => c.Description).HasMaxLength(500);
        builder.Property(c => c.CreatedBy).HasMaxLength(200);
        builder.Property(c => c.ModifiedBy).HasMaxLength(200);

        // === FK: Self-referencing parent (optional) ===
        builder.HasOne(c => c.ParentCategory)
            .WithMany(c => c.SubCategories)
            .HasForeignKey(c => c.ParentCategoryId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        // === Indexes ===
        builder.HasIndex(c => c.CategoryCode);
    }
}

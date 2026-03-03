using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vns.Erp.Domain.MasterData.Entities;

namespace Vns.Erp.Infrastructure.Persistence.Configurations.MasterData;

public class ProductAttributeConfiguration : IEntityTypeConfiguration<ProductAttribute>
{
    public void Configure(EntityTypeBuilder<ProductAttribute> builder)
    {
        builder.ToTable("ProductAttributes");

        builder.HasKey(a => a.Id);

        // === Scalar properties ===
        builder.Property(a => a.AttributeName).IsRequired().HasMaxLength(200);
        builder.Property(a => a.DataType).IsRequired().HasMaxLength(50);
        builder.Property(a => a.Description).HasMaxLength(500);
        builder.Property(a => a.CreatedBy).HasMaxLength(200);
        builder.Property(a => a.ModifiedBy).HasMaxLength(200);

        // === Indexes ===
        builder.HasIndex(a => a.AttributeName).IsUnique();
    }
}

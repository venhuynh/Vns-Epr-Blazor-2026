using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vns.Erp.Domain.MasterData.Entities;

namespace Vns.Erp.Infrastructure.Persistence.Configurations.MasterData;

public class UnitOfMeasureConfiguration : IEntityTypeConfiguration<UnitOfMeasure>
{
    public void Configure(EntityTypeBuilder<UnitOfMeasure> builder)
    {
        builder.ToTable("UnitsOfMeasure");

        builder.HasKey(u => u.Id);

        // === Scalar properties ===
        builder.Property(u => u.UnitCode).IsRequired().HasMaxLength(50);
        builder.Property(u => u.UnitName).IsRequired().HasMaxLength(200);
        builder.Property(u => u.Description).HasMaxLength(500);
        builder.Property(u => u.CreatedBy).HasMaxLength(200);
        builder.Property(u => u.ModifiedBy).HasMaxLength(200);

        // === Indexes ===
        builder.HasIndex(u => u.UnitCode).IsUnique();
    }
}

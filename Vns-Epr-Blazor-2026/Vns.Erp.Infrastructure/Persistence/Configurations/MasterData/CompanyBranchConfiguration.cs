using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vns.Erp.Domain.MasterData.Entities;

namespace Vns.Erp.Infrastructure.Persistence.Configurations.MasterData;

public class CompanyBranchConfiguration : IEntityTypeConfiguration<CompanyBranch>
{
    public void Configure(EntityTypeBuilder<CompanyBranch> builder)
    {
        builder.ToTable("CompanyBranches");

        builder.HasKey(b => b.Id);

        // === Scalar properties ===
        builder.Property(b => b.BranchCode).IsRequired().HasMaxLength(50);
        builder.Property(b => b.BranchName).IsRequired().HasMaxLength(200);
        builder.Property(b => b.Address).HasMaxLength(500);
        builder.Property(b => b.City).HasMaxLength(100);
        builder.Property(b => b.Phone).HasMaxLength(50);
        builder.Property(b => b.Fax).HasMaxLength(50);
        builder.Property(b => b.Email).HasMaxLength(200);
        builder.Property(b => b.ManagerName).HasMaxLength(200);
        builder.Property(b => b.Notes).HasMaxLength(2000);
        builder.Property(b => b.CreatedBy).HasMaxLength(200);
        builder.Property(b => b.ModifiedBy).HasMaxLength(200);

        // === Foreign Key: Company ===
        builder.HasOne(b => b.Company)
            .WithMany(c => c.Branches)
            .HasForeignKey(b => b.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        // === Indexes ===
        builder.HasIndex(b => new { b.CompanyId, b.BranchCode }).IsUnique();
    }
}

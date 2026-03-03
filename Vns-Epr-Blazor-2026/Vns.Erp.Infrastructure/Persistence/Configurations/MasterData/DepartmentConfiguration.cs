using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vns.Erp.Domain.MasterData.Entities;

namespace Vns.Erp.Infrastructure.Persistence.Configurations.MasterData;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("Departments");

        builder.HasKey(d => d.Id);

        // === Scalar properties ===
        builder.Property(d => d.DepartmentCode).IsRequired().HasMaxLength(50);
        builder.Property(d => d.DepartmentName).IsRequired().HasMaxLength(200);
        builder.Property(d => d.Description).HasMaxLength(500);
        builder.Property(d => d.CreatedBy).HasMaxLength(200);
        builder.Property(d => d.ModifiedBy).HasMaxLength(200);

        // === FK: Company (required) ===
        builder.HasOne(d => d.Company)
            .WithMany(c => c.Departments)
            .HasForeignKey(d => d.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        // === FK: CompanyBranch (optional) ===
        builder.HasOne(d => d.Branch)
            .WithMany(b => b.Departments)
            .HasForeignKey(d => d.BranchId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        // === FK: Self-referencing parent (optional) ===
        builder.HasOne(d => d.ParentDepartment)
            .WithMany(d => d.SubDepartments)
            .HasForeignKey(d => d.ParentDepartmentId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        // === Indexes ===
        builder.HasIndex(d => new { d.CompanyId, d.DepartmentCode }).IsUnique();
    }
}

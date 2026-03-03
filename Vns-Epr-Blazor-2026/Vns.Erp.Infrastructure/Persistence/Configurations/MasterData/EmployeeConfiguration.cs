using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vns.Erp.Domain.MasterData.Entities;

namespace Vns.Erp.Infrastructure.Persistence.Configurations.MasterData;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees");

        builder.HasKey(e => e.Id);

        // === Scalar — Identification ===
        builder.Property(e => e.EmployeeCode).IsRequired().HasMaxLength(50);
        builder.Property(e => e.FullName).IsRequired().HasMaxLength(200);
        builder.Property(e => e.IdentityNumber).HasMaxLength(50);
        builder.Property(e => e.IdentityIssuePlace).HasMaxLength(200);

        // === Scalar — Contact ===
        builder.Property(e => e.Phone).HasMaxLength(50);
        builder.Property(e => e.Mobile).HasMaxLength(50);
        builder.Property(e => e.Email).HasMaxLength(200);
        builder.Property(e => e.PermanentAddress).HasMaxLength(500);
        builder.Property(e => e.CurrentAddress).HasMaxLength(500);
        builder.Property(e => e.Fax).HasMaxLength(50);
        builder.Property(e => e.LinkedIn).HasMaxLength(200);
        builder.Property(e => e.Skype).HasMaxLength(100);
        builder.Property(e => e.WeChat).HasMaxLength(100);

        // === Scalar — Banking ===
        builder.Property(e => e.BankAccountNumber).HasMaxLength(50);
        builder.Property(e => e.BankName).HasMaxLength(200);
        builder.Property(e => e.BankBranch).HasMaxLength(200);

        // === Scalar — Tax & Insurance ===
        builder.Property(e => e.PersonalTaxCode).HasMaxLength(50);
        builder.Property(e => e.SocialInsuranceNumber).HasMaxLength(50);

        // === Scalar — System ===
        builder.Property(e => e.Notes).HasMaxLength(2000);
        builder.Property(e => e.CreatedBy).HasMaxLength(200);
        builder.Property(e => e.ModifiedBy).HasMaxLength(200);

        // === FK: Company (required) ===
        builder.HasOne(e => e.Company)
            .WithMany(c => c.Employees)
            .HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        // === FK: CompanyBranch (optional) ===
        builder.HasOne(e => e.Branch)
            .WithMany(b => b.Employees)
            .HasForeignKey(e => e.BranchId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        // === FK: Department (optional) ===
        builder.HasOne(e => e.Department)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.DepartmentId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        // === FK: Position (optional) ===
        builder.HasOne(e => e.Position)
            .WithMany(p => p.Employees)
            .HasForeignKey(e => e.PositionId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        // === Indexes ===
        builder.HasIndex(e => new { e.CompanyId, e.EmployeeCode }).IsUnique();
        builder.HasIndex(e => e.Email);
        builder.HasIndex(e => e.IdentityNumber);
    }
}

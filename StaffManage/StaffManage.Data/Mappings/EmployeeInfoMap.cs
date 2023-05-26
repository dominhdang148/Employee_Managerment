using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace TatBlog.Data.Mappings;

public class EmployeeInfoMap : IEntityTypeConfiguration<EmployeeInfo>
{

    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.FullName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(a => a.Gender)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(a => a.Age)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(a => a.Job)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(a => a.TimeOfWork)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(a => a.ImageUrl)
            .HasMaxLength(500);

        builder.Property(a => a.Phone)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(a => a.Birthday)
            .HasColumnType("datetime");

        builder.Property(a => a.Resident_ID)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(a => a.JoinedDate)
            .HasColumnType("datetime");

        builder.Property(a => a.Email)
            .HasMaxLength(150);

        builder.Property(a => a.Address)
            .HasMaxLength(500);
    }
}
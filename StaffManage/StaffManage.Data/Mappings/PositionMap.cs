using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StaffManage.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManage.Data.Mappings
{
    public class PositionMap : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable("Positions");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.HasOne(x => x.Department)
                .WithMany(x => x.Positions)
                .HasForeignKey(x => x.DepartmentId)
                .HasConstraintName("FK_Position_Department")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Salary)
                .WithMany(x => x.Positions)
                .HasForeignKey(x => x.SalaryId)
                .HasConstraintName("FK_Position_Salary")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

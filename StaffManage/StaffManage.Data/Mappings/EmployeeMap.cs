using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;
using StaffManage.Core.Contracts;
using StaffManage.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManage.Data.Mappings
{
    public class EmployeeMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(e => e.Id);
            builder.HasOne(e => e.Qualification)
                .WithMany(q => q.Employees)
                .HasForeignKey(e => e.QualificationId)
                .HasConstraintName("FK_Employee_Qualification")
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x=>x.Attendance)
                .WithMany(x=>x.Employees)
                .HasForeignKey(x=>x.AttendanceId)
                .HasConstraintName("FK_Employee_Attendance")
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Absence)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.AbsenceId)
                .HasConstraintName("FK_Employee_Absence")
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Work)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.WorkId)
                .HasConstraintName("FK_Employee_Work")
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.CurriculumVitae)
                .WithOne(x => x.Employee)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

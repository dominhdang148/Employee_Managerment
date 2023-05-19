using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class EmployeeMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.Gender).IsRequired();
            builder.Property(x => x.PortraitUrl).HasMaxLength(1000);
            builder.Property(x=>x.PhoneNumber).HasMaxLength(10);
            builder.Property(x=>x.DateOfBirth).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.IdentityCardNumber).IsRequired().HasMaxLength(12);
            builder.Property(x => x.Address).HasMaxLength(100);
        }
    }
}
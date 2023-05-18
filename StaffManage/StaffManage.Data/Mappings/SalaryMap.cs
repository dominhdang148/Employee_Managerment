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
    public class SalaryMap : IEntityTypeConfiguration<Salary>
    {
        public void Configure(EntityTypeBuilder<Salary> builder)
        {
            builder.ToTable("Salaries");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Amount);
            builder.Property(x => x.Bonus);
            builder.Property(x => x.Coefficient).IsRequired();
            builder.Property(x => x.Basic).IsRequired();
            builder.Property(x => x.Deduction);
        }
    }
}

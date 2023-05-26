using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;
using StaffManage.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManage.Data.Mappings
{
    public class ContractMap : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.ToTable("Contracts");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TermOfServices)
                .HasMaxLength(5000);
            builder.Property(x => x.Partner)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(x => x.EffectiveDate)
                .IsRequired()
                .HasDefaultValue(DateTime.Now);
            builder.Property(x => x.ExpireDate)
                .IsRequired();
            builder.HasOne(x => x.Payroll)
                .WithMany(x => x.Contracts)
                .HasForeignKey(x => x.PayrollId)
                .HasConstraintName("FK_Contract_Payroll")
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Employee)
                .WithMany(x => x.Contracts)
                .HasForeignKey(x => x.EmployeeId)
                .HasConstraintName("FK_Constract_Employee")
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}

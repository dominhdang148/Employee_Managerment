using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using QLNV.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNV.Data.Mappings
{
    public class PayrollMap : IEntityTypeConfiguration<Payroll>
    {
        public void Configure(EntityTypeBuilder<Payroll> builder)
        {
            builder.ToTable("Payrolls");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.TotalAmount).IsRequired();
            builder.Property(x => x.Penalty);
            builder.Property(x => x.Completment);
            builder.HasOne(x => x.Position)
                .WithMany(x => x.Payrolls)
                .HasForeignKey(x => x.PositionId)
                .HasConstraintName("FK_Payroll_Position")
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StaffManage.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManage.Data.Mappings
{
    public class AbsenceMap : IEntityTypeConfiguration<Absence>
    {
        public void Configure(EntityTypeBuilder<Absence> builder)
        {
            builder.ToTable("Absences");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.EndDate).IsRequired();
            builder.Property(x => x.Reason).IsRequired().HasMaxLength(100);
        }
    }
}

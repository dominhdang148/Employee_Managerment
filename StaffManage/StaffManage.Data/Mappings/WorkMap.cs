using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StaffManage.Core.Contracts;
using StaffManage.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManage.Data.Mappings
{
    public class WorkMap : IEntityTypeConfiguration<Work>
    {
        public void Configure(EntityTypeBuilder<Work> builder)
        {
            builder.ToTable("Works");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.Property(x => x.StartTime).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(x => x.EndTime).IsRequired();
            builder.Property(x => x.Status).IsRequired().HasMaxLength(100);
        }
    }
}

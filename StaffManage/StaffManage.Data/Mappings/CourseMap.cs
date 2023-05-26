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
    public class CourseMap : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.StartDate).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(x => x.EndDate).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(x => x.Description).HasMaxLength(1000);
           
        }
    }
}

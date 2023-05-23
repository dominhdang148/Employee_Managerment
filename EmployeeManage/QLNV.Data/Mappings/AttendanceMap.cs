﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using QLNV.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNV.Data.Mappings
{
    public class AttendanceMap : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.ToTable("Attendances");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Month);
            builder.Property(x => x.WorkDay);
            builder.Property(x => x.OffDay);
        }
    }
}

﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StaffManage.Core.Contracts;
using StaffManage.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StaffManage.Data.Mappings
{
    public class TrainingHistoryMap : IEntityTypeConfiguration<TrainingHistory>
    {
        public void Configure(EntityTypeBuilder<TrainingHistory> builder)
        {
            builder.ToTable("TrainingHistories");
            builder.HasKey(x => new { x.EmployeeId, x.CourseId });
            builder.Property(x=>x.Result).IsRequired().HasMaxLength(100);
            builder.HasOne(x => x.Employee)
                .WithMany(x => x.TrainingHistories)
                .HasForeignKey(x => x.EmployeeId)
                .HasConstraintName("FK_TrainingHistory_Employee")
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Course)
                .WithMany(x => x.TrainingHistories)
                .HasForeignKey(x => x.CourseId)
                .HasConstraintName("FK_TrainingHistory_Course")
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}

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
    public class CurriculumVitaeMap : IEntityTypeConfiguration<CurriculumVitae>
    {
        public void Configure(EntityTypeBuilder<CurriculumVitae> builder)
        {
            builder.ToTable("CVs");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.Gender).IsRequired();
            builder.Property(x => x.PortraitUrl).HasMaxLength(1000);
            builder.Property(x => x.PhoneNumber).HasMaxLength(10);
            builder.Property(x => x.DateOfBirth).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.IdentityCardNumber).IsRequired().HasMaxLength(12);
            builder.Property(x => x.JoinedDate).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.Address).HasMaxLength(100);
            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();
        }
    }
}


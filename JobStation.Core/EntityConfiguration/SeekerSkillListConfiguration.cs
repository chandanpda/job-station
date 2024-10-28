using JobStation.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStation.Core.EntityConfiguration
{
    public class SeekerSkillListConfiguration : IEntityTypeConfiguration<SeekerSkillList>
    {
        public void Configure(EntityTypeBuilder<SeekerSkillList> builder)
        {
            builder.ToTable("SeekerSkillList");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
               .HasColumnName("Id")
               .HasColumnType("int")
               .UseIdentityColumn(1, 1);

            builder.Property(x => x.SeekerId)
               .HasColumnName("SeekerId")
               .HasColumnType("int");

            builder.Property(x => x.CreatedOn)
                   .HasColumnName("CreatedOn")
                   .HasColumnType("datetimeoffset(7)")
                   .HasDefaultValueSql("getdate()")
                   .IsRequired();

            builder.Property(x => x.SeekerSkills)
              .HasColumnName("SeekerSkills")
              .HasColumnType("nvarchar")
              .HasMaxLength(200)
              .IsRequired();
        
       
        }
    }
}

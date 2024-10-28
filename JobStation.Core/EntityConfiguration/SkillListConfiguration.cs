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
    public class SkillListConfiguration : IEntityTypeConfiguration<SkillList>
    {
        public void Configure(EntityTypeBuilder<SkillList> builder)
        {
            builder.ToTable("SkillList");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
               .HasColumnName("Id")
               .HasColumnType("int")
               .UseIdentityColumn(1, 1);

            builder.Property(x => x.UniqueGuid)
              .HasColumnName("UniqueGuid")
              .HasColumnType("nvarchar")
              .HasMaxLength(50)
              .HasDefaultValueSql("NEWID()")
              .IsRequired();

            builder.Property(x => x.Name)
             .HasColumnName("Name")
             .HasColumnType("nvarchar")
             .HasMaxLength(200)
             .IsRequired();

            builder.Property(x => x.CreatedOn)
                    .HasColumnName("CreatedOn")
                    .HasColumnType("datetimeoffset(7)")
                    .HasDefaultValueSql("getdate()")
                    .IsRequired();
        }   
    }
}

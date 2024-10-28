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
    public class JobLocationConfiguration :IEntityTypeConfiguration<JobLocation>
    {
        public void Configure(EntityTypeBuilder<JobLocation> builder)
        {
            builder.ToTable("JobLocation");

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

            builder.Property(x => x.City)
            .HasColumnName("City")
            .HasColumnType("nvarchar")
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(x => x.State)
            .HasColumnName("State")
            .HasColumnType("nvarchar")
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(x => x.AddedOn)
                    .HasColumnName("AddedOn")
                    .HasColumnType("datetimeoffset(7)")
                    .HasDefaultValueSql("getdate()")
                    .IsRequired();
        }
    }
}

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
    public class JobOfferConfiguration : IEntityTypeConfiguration<JobOffer>
    {
        public void Configure(EntityTypeBuilder<JobOffer> builder)
        {
            builder.ToTable("JobOffer");

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

            builder.Property(x => x.JobCategoryId)
               .HasColumnName("CategoryId")
               .HasColumnType("int")
               .HasMaxLength(50)
               .IsRequired();

            builder.Property(x => x.Title)
               .HasColumnName("Title")
               .HasColumnType("nvarchar")
               .HasMaxLength(200)
               .IsRequired();

            builder.Property(x => x.JobTypeId)
              .HasColumnName("JobType")
              .HasColumnType("nvarchar")
              .HasMaxLength(100)
              .IsRequired();

            builder.Property(x => x.CompanyId)
             .HasColumnName("Company")
             .HasColumnType("nvarchar")
             .HasMaxLength(100)
             .IsRequired();

            builder.Property(x => x.Description)
               .HasColumnName("Description")
               .HasColumnType("nvarchar(MAX)")
               .IsRequired();

            builder.Property(x => x.Experience)
              .HasColumnName("Experience")
              .HasColumnType("int")
              .HasMaxLength(20)
              .IsRequired();

            builder.Property(x => x.Salary)
              .HasColumnName("Salary")
              .HasColumnType("nvarchar")
              .HasMaxLength(100)
              .IsRequired();

            builder.Property(x => x.LocationId)
              .HasColumnName("Location")
              .HasColumnType("nvarchar")
              .HasMaxLength(100)
              .IsRequired();

            builder.Property(x => x.IsActive)
                .HasColumnName("IsActive")
            .HasColumnType("bit")
              .HasMaxLength(5)
              .IsRequired();

            builder.Property(x => x.CreatedOn)
                    .HasColumnName("CreatedOn")
                    .HasColumnType("datetimeoffset(7)")
                    .HasDefaultValueSql("getdate()")
                    .IsRequired();

            builder.Property(x => x.UpdatedOn)
                .HasColumnName("UpdatedOn")
                .HasColumnType("datetimeoffset(7)")
                .HasDefaultValueSql("getdate()")
                .IsRequired();
        }
    }
}

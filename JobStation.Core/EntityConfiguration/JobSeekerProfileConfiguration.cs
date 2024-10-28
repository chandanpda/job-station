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
    public class JobSeekerProfileConfiguration : IEntityTypeConfiguration<JobSeekerProfile>
    {
        public  void Configure(EntityTypeBuilder<JobSeekerProfile> builder)
        {
            builder.ToTable("JobSeekerProfile");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
              .HasColumnName("Id")
              .HasColumnType("int")
              .UseIdentityColumn(1, 1);

            builder.Property(x => x.Email)
            .HasColumnName("Email")
            .HasColumnType("nvarchar")
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(x => x.FirstName)
            .HasColumnName("FirstName")
            .HasColumnType("nvarchar")
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(x => x.LastName)
            .HasColumnName("LastName")
            .HasColumnType("nvarchar")
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(x => x.Mobile)
            .HasColumnName("Title")
            .HasColumnType("nvarchar")
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(x => x.IsExperienced)
             .HasColumnName("IsExperienced")
             .HasColumnType("bit")
             .HasDefaultValue(false); 

            builder.Property(x => x.HighestQualification)
                .HasColumnName("HighestQualification")
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Branch)
                .HasColumnName("Branch")
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.InstituteName)
                .HasColumnName("InstituteName")
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Year)
               .HasColumnName("Year")
               .HasColumnType("int")
               .HasMaxLength(50)
               .IsRequired();

            builder.Property(x => x.Percentage)
               .HasColumnName("Percentage")
               .HasColumnType("int")
               .HasMaxLength(50)
               .IsRequired();

            builder.Property(x => x.StillWorking)
            .HasColumnName("StillWorking")
            .HasColumnType("bit")
            .HasDefaultValue(false); ;

            builder.Property(x => x.Title)
            .HasColumnName("Title")
            .HasColumnType("nvarchar")
            .HasMaxLength(100);

            builder.Property(x => x.CompanyName)
            .HasColumnName("CompanyName")
            .HasColumnType("nvarchar")
            .HasMaxLength(100));

            builder.Property(x => x.Location)
            .HasColumnName("Location")
            .HasColumnType("nvarchar")
            .HasMaxLength(100);

            builder.Property(x => x.StartDate)
                .HasColumnName("StartDate")
                 .HasColumnType("datetimeoffset(7)");

            builder.Property(x => x.LastDate)
                .HasColumnName("StartDate")
                 .HasColumnType("datetimeoffset(7)");

            builder.Property(x => x.CreatedOn)
               .HasColumnName("CreatedOn")
                .HasColumnType("datetimeoffset(7)")
                .IsRequired();
        }
    }
}

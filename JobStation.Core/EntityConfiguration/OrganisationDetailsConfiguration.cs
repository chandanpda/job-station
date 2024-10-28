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
    public class OrganisationDetailsConfiguration : IEntityTypeConfiguration<OrganisationDetails>
    {
        public void Configure(EntityTypeBuilder<OrganisationDetails> builder)
        {
            builder.ToTable("OrganisationDetails");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
               .HasColumnName("Id")
               .HasColumnType("int")
               .UseIdentityColumn(1, 1);

            builder.Property(x => x.OrganisationName)
              .HasColumnName("OrganisationName")
              .HasColumnType("nvarchar")
              .HasMaxLength(200)
              .IsRequired();

            builder.Property(x => x.Domain)
              .HasColumnName("Domain")
              .HasColumnType("nvarchar")
              .HasMaxLength(200)
              .IsRequired();

            builder.Property(x => x.EstablishedYear)
              .HasColumnName("EstablishedYear")
              .HasColumnType("nvarchar")
              .HasMaxLength(10)
              .IsRequired();

            builder.Property(x => x.Email)
              .HasColumnName("Email")
              .HasColumnType("nvarchar")
              .HasMaxLength(200)
              .IsRequired();

            builder.Property(x => x.Url)
              .HasColumnName("Url")
              .HasColumnType("nvarchar")
              .HasMaxLength(200);

            builder.Property(x => x.CreatedOn)
                    .HasColumnName("CreatedOn")
                    .HasColumnType("datetimeoffset(7)")
                    .HasDefaultValueSql("getdate()")
                    .IsRequired();
        }
    }
}

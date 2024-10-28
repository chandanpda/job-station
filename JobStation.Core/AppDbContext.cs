using JobStation.Core.Domain;
using JobStation.Core.EntityConfiguration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace JobStation.Core
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public virtual DbSet<JobCategory> JobCategories { get; set; }
        public virtual DbSet<JobType> JobTypes { get; set; }
        public virtual DbSet<JobOffer> JobOffers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new JobTypeConfiguration());
            modelBuilder.ApplyConfiguration(new JobOfferConfiguration());
            modelBuilder.ApplyConfiguration(new JobCategoryConfiguration());
        }
    }
}

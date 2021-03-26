using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Task3B.Data.Models;

namespace Task3B.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserDbEntity>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CustomerDbEntity> Customers { get; set; }
        public DbSet<CustomerServiceDbEntity> CustomerServices { get; set; }
        public DbSet<ServiceDbEntity> Services { get; set; }
        public DbSet<ServiceProviderDbEntity> ServiceProviders { get; set; }
        public DbSet<FileDbEntity> Files { get; set; }
        public DbSet<SectionDbEntity> Sections { get; set; }
        public DbSet<SubSectionDbEntity> SubSections { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<CustomerServiceDbEntity>().HasKey(x => new { x.CustomerId, x.ServiceId});
            builder.Entity<CustomerDbEntity>().HasQueryFilter(x => !x.IsDeleted);
            builder.Entity<CustomerServiceDbEntity>().HasQueryFilter(x => !x.IsDeleted);
            builder.Entity<ServiceDbEntity>().HasQueryFilter(x => !x.IsDeleted);
            builder.Entity<ServiceProviderDbEntity>().HasQueryFilter(x => !x.IsDeleted);
            builder.Entity<SectionDbEntity>().HasQueryFilter(x => !x.IsDeleted);
            builder.Entity<SubSectionDbEntity>().HasQueryFilter(x => !x.IsDeleted);
        }
    }
}

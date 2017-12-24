using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using AsphaltsProducts.Domain.Models;
using AsphaltsProducts.Domain.Models.ECommerce;

namespace AsphaltsProducts.Infrastructure.Contexts
{
    public interface IAsphaltsDbContext
    {
        //DbSet<Employee> Employees { get; set; }
        DbSet<ApplicationUser> ApplicationUsers { get; set; }
        DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductCategory> ProductCategory { get; set; }
    }


    public class AsphaltsDbContext : DbContext, IAsphaltsDbContext
    {
        public AsphaltsDbContext(DbContextOptions options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().ToTable("ApplicationUsers");
            modelBuilder.Entity<ApplicationUserRole>().ToTable("ApplicationUserRoles");
            //modelBuilder.Entity<Employee>().ToTable("Employees");    
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<ProductCategory>().ToTable("ProductCategories");

        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }

    }

    
}

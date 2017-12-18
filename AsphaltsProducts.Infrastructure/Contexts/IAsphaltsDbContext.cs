using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using AsphaltsProducts.Domain.Models;

namespace AsphaltsProducts.Infrastructure.Contexts
{
    public interface IAsphaltsDbContext
    {
        //DbSet<Employee> Employees { get; set; }
        DbSet<ApplicationUser> ApplicationUsers { get; set; }
        DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }
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
            
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }
    }

    
}

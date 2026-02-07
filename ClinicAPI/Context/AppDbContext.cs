using Clinic.API.Models;
using ClinicAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Clinic.API.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }


        //Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //User Entity
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<User>().
                Property(u => u.UserId).
                ValueGeneratedOnAdd();

            modelBuilder.Entity<User>().
                Property(u => u.CPF).
                HasMaxLength(11).IsRequired();

            modelBuilder.Entity<User>().
                HasIndex(u => u.CPF).
                IsUnique();

            modelBuilder.Entity<User>().
                Property(u => u.Name).
                HasMaxLength(100).IsRequired();

            modelBuilder.Entity<User>().
                Property(u => u.Email).
                HasMaxLength(100).IsRequired(false);

            modelBuilder.Entity<User>().
                Property(u => u.PasswordHash).
                HasMaxLength(256).IsRequired();

            modelBuilder.Entity<User>().
               Property(u => u.Role).
              HasConversion<int>().IsRequired();

            modelBuilder.Entity<User>().
                OwnsOne(u => u.Address, address =>
                {
                    address.Property(a => a.Street).HasMaxLength(200).IsRequired();
                    address.Property(a => a.City).HasMaxLength(40).IsRequired();
                    address.Property(a => a.State).HasMaxLength(40).IsRequired();
                    address.Property(a => a.ZipCode).HasMaxLength(8).IsRequired();
                });
        }
    }
}


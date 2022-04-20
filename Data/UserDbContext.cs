﻿using Apartment_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Apartment_Management.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Tckn)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.PhoneNumber)
                .IsUnique();

            modelBuilder.Entity<Flat>().ToTable("Flat");

            modelBuilder.Entity<FlatAssignment>().ToTable("FlatAssignment");

            modelBuilder.Entity<FlatAssignment>()
                .HasIndex(f => f.FlatID)
                .IsUnique();
        }

    }
}

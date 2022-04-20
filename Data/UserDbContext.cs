using Apartment_Management.Models;
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

            modelBuilder.Entity<Flat>()
                .ToTable("Flat")
                .HasKey(f => new {f.BlockCode, f.DoorNum});

            modelBuilder.Entity<FlatAssignment>()
                .ToTable("FlatAssignment")
                .HasIndex(f => f.FlatID)
                .IsUnique();

            modelBuilder.Entity<Period>()
                .ToTable("Period")
                .HasIndex(p => p.Name)
                .IsUnique();

            modelBuilder.Entity<BillType>()
                .ToTable("BillType")
                .HasIndex(bt => bt.Name)
                .IsUnique();

            modelBuilder.Entity<Bill>()
                .ToTable("Bill")
                .HasKey(b => new { b.FlatID, b.PeriodID, b.BillTypeID });

            modelBuilder.Entity<Message>().ToTable("Message");

            modelBuilder.Entity<Payment>().ToTable("Payment");
        }

    }
}

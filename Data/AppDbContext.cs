using Apartment_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Apartment_Management.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Flat> Flats { get; set; }
        public DbSet<FlatAssignment> FlatAssignments { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<BillType> BillTypes { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<BankCard> BankCards { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

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

            modelBuilder.Entity<BankCard>().ToTable("BankCard");

            modelBuilder.Entity<Vehicle>()
                .ToTable("Vehicle")
                .HasIndex(v => v.Plate)
                .IsUnique();
        }

    }
}

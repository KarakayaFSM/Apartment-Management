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
        public DbSet<InvoiceType> BillTypes { get; set; }
        public DbSet<Invoice> Bills { get; set; }
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
                .HasIndex(f => new { f.BlockCode, f.DoorNum })
                .IsUnique();

            modelBuilder.Entity<FlatAssignment>()
                .ToTable("FlatAssignment")
                .HasIndex(f => f.FlatID)
                .IsUnique();

            modelBuilder.Entity<FlatAssignment>()
                .HasKey(fa => new { fa.FlatID, fa.UserID });

            modelBuilder.Entity<Period>()
                .ToTable("Period")
                .HasIndex(p => p.Name)
                .IsUnique();

            modelBuilder.Entity<InvoiceType>()
                .ToTable("BillType")
                .HasIndex(bt => bt.Name)
                .IsUnique();

            modelBuilder.Entity<Invoice>()
                .ToTable("Invoice")
                .HasKey(b => new { b.FlatID, b.PeriodID, b.InvoiceTypeID });

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

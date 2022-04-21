﻿// <auto-generated />
using System;
using Apartment_Management.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Apartment_Management.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Apartment_Management.Models.BankCard", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CVV")
                        .HasColumnType("int");

                    b.Property<string>("CardHolderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CardNumber")
                        .HasColumnType("int");

                    b.Property<int>("ExpireMonth")
                        .HasColumnType("int");

                    b.Property<int>("ExpireYear")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("BankCard");
                });

            modelBuilder.Entity("Apartment_Management.Models.Flat", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BlockCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("DoorNum")
                        .HasColumnType("int");

                    b.Property<string>("FlatLabel")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FlatSize")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<bool>("IsFull")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("FlatLabel")
                        .IsUnique();

                    b.HasIndex("BlockCode", "DoorNum")
                        .IsUnique();

                    b.ToTable("Flat");
                });

            modelBuilder.Entity("Apartment_Management.Models.FlatAssignment", b =>
                {
                    b.Property<int>("FlatID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("FlatID", "UserID");

                    b.HasIndex("FlatID")
                        .IsUnique();

                    b.HasIndex("UserID");

                    b.ToTable("FlatAssignment");
                });

            modelBuilder.Entity("Apartment_Management.Models.Invoice", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FlatID")
                        .HasColumnType("int");

                    b.Property<int>("InvoiceTypeID")
                        .HasColumnType("int");

                    b.Property<int>("PeriodID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("InvoiceTypeID");

                    b.HasIndex("PeriodID");

                    b.HasIndex("FlatID", "PeriodID", "InvoiceTypeID")
                        .IsUnique();

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("Apartment_Management.Models.InvoiceType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Charge")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("InvoiceType");
                });

            modelBuilder.Entity("Apartment_Management.Models.Message", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("Apartment_Management.Models.Payment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("FlatID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("FlatID");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("Apartment_Management.Models.Period", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("PeriodDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Period");
                });

            modelBuilder.Entity("Apartment_Management.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnName("PhoneNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Tckn")
                        .IsRequired()
                        .HasColumnName("Tckn")
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.HasKey("ID");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.HasIndex("Tckn")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("Apartment_Management.Models.Vehicle", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Plate")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Plate")
                        .IsUnique()
                        .HasFilter("[Plate] IS NOT NULL");

                    b.HasIndex("UserID");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("Apartment_Management.Models.BankCard", b =>
                {
                    b.HasOne("Apartment_Management.Models.User", "User")
                        .WithMany("Cards")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Apartment_Management.Models.FlatAssignment", b =>
                {
                    b.HasOne("Apartment_Management.Models.Flat", "Flat")
                        .WithMany()
                        .HasForeignKey("FlatID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Apartment_Management.Models.User", "User")
                        .WithMany("FlatAssignments")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Apartment_Management.Models.Invoice", b =>
                {
                    b.HasOne("Apartment_Management.Models.Flat", "Flat")
                        .WithMany("Invoices")
                        .HasForeignKey("FlatID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Apartment_Management.Models.InvoiceType", "InvoiceType")
                        .WithMany()
                        .HasForeignKey("InvoiceTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Apartment_Management.Models.Period", "Period")
                        .WithMany()
                        .HasForeignKey("PeriodID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Apartment_Management.Models.Message", b =>
                {
                    b.HasOne("Apartment_Management.Models.User", "User")
                        .WithMany("Messages")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Apartment_Management.Models.Payment", b =>
                {
                    b.HasOne("Apartment_Management.Models.Flat", "Flat")
                        .WithMany("Payments")
                        .HasForeignKey("FlatID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Apartment_Management.Models.Vehicle", b =>
                {
                    b.HasOne("Apartment_Management.Models.User", "User")
                        .WithMany("Vehicles")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

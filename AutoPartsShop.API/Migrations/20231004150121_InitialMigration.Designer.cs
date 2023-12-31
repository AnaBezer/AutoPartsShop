﻿// <auto-generated />
using AutoPartsShop.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AutoPartsShop.API.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20231004150121_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AutoPartsShop.API.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Carts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("AutoPartsShop.API.Models.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("AutoPartsShop.API.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 50142,
                            Brand = "BREMBO",
                            CategoryId = 1,
                            Description = "Front axle, prepared for wear indicator, without accessories, OENs: A0004206600, 0074206520, A0044208920 — MERCEDES-BENZ",
                            ImageURL = "Images/Brakes/1preview.jpg",
                            Price = 49.990000000000002,
                            ProductName = "Brake Pads",
                            Qty = 50
                        },
                        new
                        {
                            Id = 9931333,
                            Brand = "BREMBO",
                            CategoryId = 1,
                            Description = "Front axle, 390x36mm, 5, slotted/perforated, Two-piece brake disc, internally vented, Coated, High-carbon, with bolts/screws, OENs: A2304211212, 2304211212 — MERCEDES-BENZ",
                            ImageURL = "Images/Brakes/2preview.jpg",
                            Price = 39.990000000000002,
                            ProductName = "Brake Discs",
                            Qty = 50
                        },
                        new
                        {
                            Id = 986494972,
                            Brand = "BOSCH",
                            CategoryId = 1,
                            Description = "Rear Axle, Low-Metallic, with anti-squeak plate, with mounting manual, suitable for MERCEDES-BENZ 190 (W201), OENs: A 001 420 01 20, 001 420 01 20.",
                            ImageURL = "Images/Brakes/3preview.jpg",
                            Price = 49.990000000000002,
                            ProductName = "Brake Pads",
                            Qty = 50
                        },
                        new
                        {
                            Id = 986479331,
                            Brand = "BOSCH",
                            CategoryId = 1,
                            Description = "Rear Axle, 295x28mm, 5x112, Perforated, Vented, Coated, High-carbon, OEN 839 615 301, 175 615 301 — MERCEDES-BENZ",
                            ImageURL = "Images/Brakes/4preview.jpg",
                            Price = 35.990000000000002,
                            ProductName = "Brake Discs",
                            Qty = 50
                        },
                        new
                        {
                            Id = 801245,
                            Brand = "MANN-FILTER",
                            CategoryId = 2,
                            Description = "with seal, Filter Insert, OENs: 5003 968, 1536 304 — — MERCEDES-BENZ",
                            ImageURL = "Images/Filters/5preview.jpg",
                            Price = 19.989999999999998,
                            ProductName = "Oil Filter",
                            Qty = 50
                        },
                        new
                        {
                            Id = 514535,
                            Brand = "MANN-FILTER",
                            CategoryId = 2,
                            Description = "with seal, OENs: 5003 968, 1536 304 — — MERCEDES-BENZ",
                            ImageURL = "Images/Filters/6preview.jpg",
                            Price = 19.989999999999998,
                            ProductName = "Fuel Filter",
                            Qty = 50
                        },
                        new
                        {
                            Id = 3112364,
                            Brand = "MANN-FILTER",
                            CategoryId = 2,
                            Description = "42mm, 209mm, 309mm, Filter Insert, OENs: 5073 968, 1736 304 — — MERCEDES-BENZ",
                            ImageURL = "Images/Filters/7preview.jpg",
                            Price = 19.989999999999998,
                            ProductName = "Air Filter",
                            Qty = 0
                        },
                        new
                        {
                            Id = 46729005,
                            Brand = "MANN-FILTER",
                            CategoryId = 2,
                            Description = "Activated Carbon Filter, 264 mm x 284 mm x 44 mm, OENs: 5303 968, 1936 304 — — MERCEDES-BENZ",
                            ImageURL = "Images/Filters/8preview.jpg",
                            Price = 19.989999999999998,
                            ProductName = "Cabin Filter",
                            Qty = 0
                        },
                        new
                        {
                            Id = 586624,
                            Brand = "VALEO",
                            CategoryId = 2,
                            Description = "Filter Insert, OENs: L321-14-302, L321-14-302-9A — MERCEDES-BENZ",
                            ImageURL = "Images/Filters/9preview.jpg",
                            Price = 19.989999999999998,
                            ProductName = "Oil Filter",
                            Qty = 50
                        },
                        new
                        {
                            Id = 585064,
                            Brand = "VALEO",
                            CategoryId = 2,
                            Description = "57mm, 77mm, 188mm, Filter Insert, OENs: 8200104272, 1736457304 — MERCEDES-BENZ",
                            ImageURL = "Images/Filters/10preview.jpg",
                            Price = 19.989999999999998,
                            ProductName = "Air Filter",
                            Qty = 50
                        },
                        new
                        {
                            Id = 2198276,
                            Brand = "TOTAL",
                            CategoryId = 3,
                            Description = "5W-40, 1l, Oil Viscosity Classification SAE, Specification: API SN, ACEA A3/B3, API CF, ACEA A3/B4.",
                            ImageURL = "Images/Oils/11preview.jpg",
                            Price = 9.9900000000000002,
                            ProductName = "Engine Oil",
                            Qty = 50
                        },
                        new
                        {
                            Id = 2626,
                            Brand = "LIQUI MOLY",
                            CategoryId = 3,
                            Description = "10W-40, 1l, Part Synthetic Oil, Specification: ACEA A3/B3, API SL, ACEA A3/B4, API CF.",
                            ImageURL = "Images/Oils/12preview.jpg",
                            Price = 9.9900000000000002,
                            ProductName = "Engine Oil",
                            Qty = 50
                        },
                        new
                        {
                            Id = 5130,
                            Brand = "LIQUI MOLY",
                            CategoryId = 3,
                            Description = "Tin, Contents: 150ml, Diesel, OEN P000032 — LIQUI MOLY.",
                            ImageURL = "Images/Oils/13preview.jpg",
                            Price = 9.9900000000000002,
                            ProductName = "Fuel Additive",
                            Qty = 50
                        },
                        new
                        {
                            Id = 2172768,
                            Brand = "TOTAL",
                            CategoryId = 3,
                            Description = "G11 Blue, 1l, Specification: G11.",
                            ImageURL = "Images/Oils/14preview.jpg",
                            Price = 9.9900000000000002,
                            ProductName = "Antifreeze",
                            Qty = 50
                        });
                });

            modelBuilder.Entity("AutoPartsShop.API.Models.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Brakes"
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Filters"
                        },
                        new
                        {
                            Id = 3,
                            CategoryName = "Oils"
                        });
                });

            modelBuilder.Entity("AutoPartsShop.API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            UserName = "Ana"
                        },
                        new
                        {
                            Id = 2,
                            UserName = "Maria"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

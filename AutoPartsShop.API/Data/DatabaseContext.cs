using AutoPartsShop.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsShop.API.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Add Product Categories 
            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
            {
                Id = 1,
                CategoryName = "Brakes",
            });

            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
            {
                Id = 2,
                CategoryName = "Filters",
            });

            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
            {
                Id = 3,
                CategoryName = "Oils",
            });

            // Products
            // Brakes Category
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 50142,
                ProductName = "Brake Pads",
                Brand = "BREMBO",
                Price = 49.99,
                Qty = 50,
                ImageURL = "Images/Brakes/1preview.jpg",
                Description = "Front axle, prepared for wear indicator, without accessories, OENs: A0004206600, 0074206520, A0044208920 — MERCEDES-BENZ",
                CategoryId = 1
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductName = "Brake Discs",
                Id = 9931333,
                Brand = "BREMBO",
                Price = 39.99,
                ImageURL = "Images/Brakes/2preview.jpg",
                Description = "Front axle, 390x36mm, 5, slotted/perforated, Two-piece brake disc, internally vented, Coated, High-carbon, with bolts/screws, OENs: A2304211212, 2304211212 — MERCEDES-BENZ",
                CategoryId = 1,
                Qty = 50
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductName = "Brake Pads",
                Id = 986494972,
                Brand = "BOSCH",
                Price = 49.99,
                ImageURL = "Images/Brakes/3preview.jpg",
                Description = "Rear Axle, Low-Metallic, with anti-squeak plate, with mounting manual, suitable for MERCEDES-BENZ 190 (W201), OENs: A 001 420 01 20, 001 420 01 20.",
                CategoryId = 1,
                Qty = 50
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductName = "Brake Discs",
                Id = 986479331,
                Brand = "BOSCH",
                Price = 35.99,
                ImageURL = "Images/Brakes/4preview.jpg",
                Description = "Rear Axle, 295x28mm, 5x112, Perforated, Vented, Coated, High-carbon, OEN 839 615 301, 175 615 301 — MERCEDES-BENZ",
                CategoryId = 1,
                Qty = 50
            });

            // Filters Category
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductName = "Oil Filter",
                Id = 801245,
                Brand = "MANN-FILTER",
                Price = 19.99,
                ImageURL = "Images/Filters/5preview.jpg",
                Description = "with seal, Filter Insert, OENs: 5003 968, 1536 304 — — MERCEDES-BENZ",
                CategoryId = 2,
                Qty = 50
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductName = "Fuel Filter",
                Id = 514535,
                Brand = "MANN-FILTER",
                Price = 19.99,
                ImageURL = "Images/Filters/6preview.jpg",
                Description = "with seal, OENs: 5003 968, 1536 304 — — MERCEDES-BENZ",
                CategoryId = 2,
                Qty = 50
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductName = "Air Filter",
                Id = 3112364,
                Brand = "MANN-FILTER",
                Price = 19.99,
                ImageURL = "Images/Filters/7preview.jpg",
                Description = "42mm, 209mm, 309mm, Filter Insert, OENs: 5073 968, 1736 304 — — MERCEDES-BENZ",
                CategoryId = 2,
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductName = "Cabin Filter",
                Id = 46729005,
                Brand = "MANN-FILTER",
                Price = 19.99,
                ImageURL = "Images/Filters/8preview.jpg",
                Description = "Activated Carbon Filter, 264 mm x 284 mm x 44 mm, OENs: 5303 968, 1936 304 — — MERCEDES-BENZ",
                CategoryId = 2,
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductName = "Oil Filter",
                Id = 586624,
                Brand = "VALEO",
                Price = 19.99,
                ImageURL = "Images/Filters/9preview.jpg",
                Description = "Filter Insert, OENs: L321-14-302, L321-14-302-9A — MERCEDES-BENZ",
                CategoryId = 2,
                Qty = 50
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductName = "Air Filter",
                Id = 585064,
                Brand = "VALEO",
                Price = 19.99,
                ImageURL = "Images/Filters/10preview.jpg",
                Description = "57mm, 77mm, 188mm, Filter Insert, OENs: 8200104272, 1736457304 — MERCEDES-BENZ",
                CategoryId = 2,
                Qty = 50
            });

            // Oils Category
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductName = "Engine Oil",
                Id = 2198276,
                Brand = "TOTAL",
                Price = 9.99,
                ImageURL = "Images/Oils/11preview.jpg",
                Description = "5W-40, 1l, Oil Viscosity Classification SAE, Specification: API SN, ACEA A3/B3, API CF, ACEA A3/B4.",
                CategoryId = 3,
                Qty = 50
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductName = "Engine Oil",
                Id = 2626,
                Brand = "LIQUI MOLY",
                Price = 9.99,
                ImageURL = "Images/Oils/12preview.jpg",
                Description = "10W-40, 1l, Part Synthetic Oil, Specification: ACEA A3/B3, API SL, ACEA A3/B4, API CF.",
                CategoryId = 3,
                Qty = 50
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductName = "Fuel Additive",
                Id = 5130,
                Brand = "LIQUI MOLY",
                Price = 9.99,
                ImageURL = "Images/Oils/13preview.jpg",
                Description = "Tin, Contents: 150ml, Diesel, OEN P000032 — LIQUI MOLY.",
                CategoryId = 3,
                Qty = 50
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductName = "Antifreeze",
                Id = 2172768,
                Brand = "TOTAL",
                Price = 9.99,
                ImageURL = "Images/Oils/14preview.jpg",
                Description = "G11 Blue, 1l, Specification: G11.",
                CategoryId = 3,
                Qty = 50
            });

            //Add users
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                UserName = "Ana"

            });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 2,
                UserName = "Maria"

            });

            //Create Shopping Cart for Users
            modelBuilder.Entity<Cart>().HasData(new Cart
            {
                Id = 1,
                UserId = 1

            });
            modelBuilder.Entity<Cart>().HasData(new Cart
            {
                Id = 2,
                UserId = 2

            });


        }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

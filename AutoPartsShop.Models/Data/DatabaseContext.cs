using Microsoft.EntityFrameworkCore;
using AutoPartsShop.DataAccess.Entities;

namespace AutoPartsShop.DataAccess.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Primary Keys
            modelBuilder.Entity<ProductCategory>().HasKey(pc => pc.Id);
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<ShoppingCart>().HasKey(sc => sc.Id);
            modelBuilder.Entity<ShoppingCartProduct>().HasKey(scp => scp.Id);
            modelBuilder.Entity<User>().HasKey(u => u.Id);

            // Relationships and Cascade Delete
            modelBuilder.Entity<Product>()
                .HasOne<ProductCategory>()
                .WithMany()
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ShoppingCartProduct>()
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(scp => scp.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // Data Seeding 
            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
            {
                Id = 1,
                CategoryName = "Brakes",
                IconCSS = "fas fa-compact-disc"
            });

            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
            {
                Id = 2,
                CategoryName = "Filters",
                IconCSS = "fab fa-creative-commons-share",
            });

            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
            {
                Id = 3,
                CategoryName = "Oils",
                IconCSS = "fas fa-oil-can"
            });

            // Products
            // Brakes Category
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 50142,
                ProductName = "Brake Pads",
                Brand = "BREMBO",
                Price = 699,
                Qty = 50,
                ImageURL = "Images/Brakes/1.1preview.jpg",
                Description = "Front axle, prepared for wear indicator, without accessories." +
                              "OENs: A0004206600, 0074206520, A0044208920 — MERCEDES-BENZ",
                CategoryId = 1
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductName = "Brake Discs",
                Id = 9931333,
                Brand = "BREMBO",
                Price = 699,
                ImageURL = "Images/Brakes/2preview.jpg",
                Description = "Front axle, 390x36mm, 5, slotted/perforated. " +
                "              Two-piece brake disc, internally vented." +
                "              Coated, High-carbon, with bolts/screws." +
                "              OENs: A2304211212, 2304211212 — MERCEDES-BENZ",
                CategoryId = 1,
                Qty = 50
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductName = "Brake Pads",
                Id = 986494972,
                Brand = "BOSCH",
                Price = 799,
                ImageURL = "Images/Brakes/3preview.jpg",
                Description = "Rear Axle, Low-Metallic, with anti-squeak plate, with mounting manual." +
                "              OENs: A 001 420 01 20, 001 420 01 20.",
                CategoryId = 1,
                Qty = 50
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductName = "Brake Discs",
                Id = 986479331,
                Brand = "BOSCH",
                Price = 799,
                ImageURL = "Images/Brakes/4preview.jpg",
                Description = "Rear Axle, 295x28mm, 5x112, Perforated, Vented, Coated, High-carbon." +
                "              OEN 839 615 301, 175 615 301 — MERCEDES-BENZ",
                CategoryId = 1,
                Qty = 50
            });

            // Filters Category
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductName = "Oil Filter",
                Id = 801245,
                Brand = "MANN-FILTER",
                Price = 299,
                ImageURL = "Images/Filters/6preview.jpg",
                Description = "With seal, Filter Insert." +
                "              OENs: 5003 968, 1536 304 — MERCEDES-BENZ",
                CategoryId = 2,
                Qty = 50
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductName = "Fuel Filter",
                Id = 514535,
                Brand = "MANN-FILTER",
                Price = 299,
                ImageURL = "Images/Filters/7preview.jpg",
                Description = "With seal." +
                "              OENs: 5003 968, 1536 304 — MERCEDES-BENZ",
                CategoryId = 2,
                Qty = 50
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductName = "Air Filter",
                Id = 3112364,
                Brand = "MANN-FILTER",
                Price = 299,
                ImageURL = "Images/Filters/8preview.jpg",
                Description = "42mm, 209mm, 309mm, Filter Insert." +
                "              OENs: 5073 968, 1736 304 — MERCEDES-BENZ",
                CategoryId = 2,
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductName = "Cabin Filter",
                Id = 46729005,
                Brand = "MANN-FILTER",
                Price = 299,
                ImageURL = "Images/Filters/9preview.jpg",
                Description = "Activated Carbon Filter, 264 mm x 284 mm x 44 mm." +
                "              OENs: 5303 968, 1936 304 — MERCEDES-BENZ",
                CategoryId = 2,
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductName = "Oil Filter",
                Id = 586624,
                Brand = "VALEO",
                Price = 299,
                ImageURL = "Images/Filters/10preview.jpg",
                Description = "Filter Insert." +
                "              OENs: L321-14-302, L321-14-302-9A — MERCEDES-BENZ",
                CategoryId = 2,
                Qty = 50
            });

            // Oils Category
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductName = "Engine Oil",
                Id = 2198276,
                Brand = "TOTAL",
                Price = 99.99,
                ImageURL = "Images/Oils/11preview.jpg",
                Description = "5W-40, 1l, Oil Viscosity Classification SAE." +
                "              Specification: API SN, ACEA A3/B3, API CF, ACEA A3/B4.",
                CategoryId = 3,
                Qty = 50
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductName = "Engine Oil",
                Id = 2626,
                Brand = "LIQUI MOLY",
                Price = 99.99,
                ImageURL = "Images/Oils/12preview.jpg",
                Description = "10W-40, 1l, Part Synthetic Oil." +
                "              Specification: ACEA A3/B3, API SL, ACEA A3/B4, API CF.",
                CategoryId = 3,
                Qty = 50
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductName = "Fuel Additive",
                Id = 5130,
                Brand = "LIQUI MOLY",
                Price = 99.99,
                ImageURL = "Images/Oils/13preview.jpg",
                Description = "Tin, Contents: 150ml, Diesel." +
                "              OEN P000032 — LIQUI MOLY.",
                CategoryId = 3,
                Qty = 50
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductName = "Antifreeze",
                Id = 2172768,
                Brand = "TOTAL",
                Price = 99.99,
                ImageURL = "Images/Oils/14preview.jpg",
                Description = "G11 Blue, 1l. " +
                "              Specification: G11.",
                CategoryId = 3,
                Qty = 50
            });

            //Add users
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                UserName = "Ana",
                Password = "password"

            });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 2,
                UserName = "Maria",
                Password = "password"

            });

            //Create Shopping Cart for Users
            modelBuilder.Entity<ShoppingCart>().HasData(new ShoppingCart
            {
                Id = 1,
                UserId = 1

            });
            modelBuilder.Entity<ShoppingCart>().HasData(new ShoppingCart
            {
                Id = 2,
                UserId = 2

            });
        }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartProduct> ShoppingCartProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutoPartsShop.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconCSS = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CategoryName", "IconCSS" },
                values: new object[,]
                {
                    { 1, "Brakes", "fas fa-compact-disc" },
                    { 2, "Filters", "fab fa-creative-commons-share" },
                    { 3, "Oils", "fas fa-oil-can" }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCarts",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "password", "Ana" },
                    { 2, "password", "Maria" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "CategoryId", "Description", "ImageURL", "Price", "ProductName", "Qty" },
                values: new object[,]
                {
                    { 2626, "LIQUI MOLY", 3, "10W-40, 1l, Part Synthetic Oil.              Specification: ACEA A3/B3, API SL, ACEA A3/B4, API CF.", "Images/Oils/12preview.jpg", 99.989999999999995, "Engine Oil", 50 },
                    { 5130, "LIQUI MOLY", 3, "Tin, Contents: 150ml, Diesel.              OEN P000032 — LIQUI MOLY.", "Images/Oils/13preview.jpg", 99.989999999999995, "Fuel Additive", 50 },
                    { 50142, "BREMBO", 1, "Front axle, prepared for wear indicator, without accessories.OENs: A0004206600, 0074206520, A0044208920 — MERCEDES-BENZ", "Images/Brakes/1.1preview.jpg", 699.0, "Brake Pads", 50 },
                    { 514535, "MANN-FILTER", 2, "With seal.              OENs: 5003 968, 1536 304 — MERCEDES-BENZ", "Images/Filters/7preview.jpg", 299.0, "Fuel Filter", 50 },
                    { 586624, "VALEO", 2, "Filter Insert.              OENs: L321-14-302, L321-14-302-9A — MERCEDES-BENZ", "Images/Filters/10preview.jpg", 299.0, "Oil Filter", 50 },
                    { 801245, "MANN-FILTER", 2, "With seal, Filter Insert.              OENs: 5003 968, 1536 304 — MERCEDES-BENZ", "Images/Filters/6preview.jpg", 299.0, "Oil Filter", 50 },
                    { 2172768, "TOTAL", 3, "G11 Blue, 1l.               Specification: G11.", "Images/Oils/14preview.jpg", 99.989999999999995, "Antifreeze", 50 },
                    { 2198276, "TOTAL", 3, "5W-40, 1l, Oil Viscosity Classification SAE.              Specification: API SN, ACEA A3/B3, API CF, ACEA A3/B4.", "Images/Oils/11preview.jpg", 99.989999999999995, "Engine Oil", 50 },
                    { 3112364, "MANN-FILTER", 2, "42mm, 209mm, 309mm, Filter Insert.              OENs: 5073 968, 1736 304 — MERCEDES-BENZ", "Images/Filters/8preview.jpg", 299.0, "Air Filter", 0 },
                    { 9931333, "BREMBO", 1, "Front axle, 390x36mm, 5, slotted/perforated.               Two-piece brake disc, internally vented.              Coated, High-carbon, with bolts/screws.              OENs: A2304211212, 2304211212 — MERCEDES-BENZ", "Images/Brakes/2preview.jpg", 699.0, "Brake Discs", 50 },
                    { 46729005, "MANN-FILTER", 2, "Activated Carbon Filter, 264 mm x 284 mm x 44 mm.              OENs: 5303 968, 1936 304 — MERCEDES-BENZ", "Images/Filters/9preview.jpg", 299.0, "Cabin Filter", 0 },
                    { 986479331, "BOSCH", 1, "Rear Axle, 295x28mm, 5x112, Perforated, Vented, Coated, High-carbon.              OEN 839 615 301, 175 615 301 — MERCEDES-BENZ", "Images/Brakes/4preview.jpg", 799.0, "Brake Discs", 50 },
                    { 986494972, "BOSCH", 1, "Rear Axle, Low-Metallic, with anti-squeak plate, with mounting manual.              OENs: A 001 420 01 20, 001 420 01 20.", "Images/Brakes/3preview.jpg", 799.0, "Brake Pads", 50 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartProducts_ProductId",
                table: "ShoppingCartProducts",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCartProducts");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductCategories");
        }
    }
}

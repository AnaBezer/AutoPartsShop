using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoPartsShop.API.Migrations
{
    /// <inheritdoc />
    public partial class IconsCSSUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "IconCSS",
                value: "fas fa-compact-disc");

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "IconCSS",
                value: "fab fa-creative-commons-share");

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "IconCSS",
                value: "fas fa-oil-can");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 801245,
                column: "Description",
                value: "With seal, Filter Insert.              OENs: 5003 968, 1536 304 — MERCEDES-BENZ");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46729005,
                column: "Description",
                value: "Activated Carbon Filter, 264 mm x 284 mm x 44 mm.              OENs: 5303 968, 1936 304 — MERCEDES-BENZ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "IconCSS",
                value: "fas fa-compact-disc	");

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "IconCSS",
                value: "filter_tilt_shift");

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "IconCSS",
                value: "fas fa-oil-can	");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 801245,
                column: "Description",
                value: "With seal, Filter Insert.              OENs: 5003 968, 1536 304 — — MERCEDES-BENZ");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46729005,
                column: "Description",
                value: "Activated Carbon Filter, 264 mm x 284 mm x 44 mm.              OENs: 5303 968, 1936 304 — — MERCEDES-BENZ");
        }
    }
}

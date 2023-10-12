using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoPartsShop.API.Migrations
{
    /// <inheritdoc />
    public partial class AddProductCategoryIcons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IconCSS",
                table: "ProductCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconCSS",
                table: "ProductCategories");
        }
    }
}

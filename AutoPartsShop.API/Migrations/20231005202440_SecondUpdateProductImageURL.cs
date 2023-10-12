using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoPartsShop.API.Migrations
{
    /// <inheritdoc />
    public partial class SecondUpdateProductImageURL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2626,
                column: "Price",
                value: 99.989999999999995);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5130,
                column: "Price",
                value: 99.989999999999995);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50142,
                columns: new[] { "ImageURL", "Price" },
                values: new object[] { "Images/Brakes/1.1preview.jpg", 699.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 514535,
                column: "Price",
                value: 299.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 586624,
                column: "Price",
                value: 299.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 801245,
                column: "Price",
                value: 299.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2172768,
                column: "Price",
                value: 99.989999999999995);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2198276,
                column: "Price",
                value: 99.989999999999995);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3112364,
                column: "Price",
                value: 299.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9931333,
                column: "Price",
                value: 699.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46729005,
                column: "Price",
                value: 299.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 986479331,
                column: "Price",
                value: 799.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 986494972,
                column: "Price",
                value: 799.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2626,
                column: "Price",
                value: 9.9900000000000002);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5130,
                column: "Price",
                value: 9.9900000000000002);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50142,
                columns: new[] { "ImageURL", "Price" },
                values: new object[] { "Images/Brakes/1.preview.jpg", 49.990000000000002 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 514535,
                column: "Price",
                value: 19.989999999999998);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 586624,
                column: "Price",
                value: 19.989999999999998);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 801245,
                column: "Price",
                value: 19.989999999999998);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2172768,
                column: "Price",
                value: 9.9900000000000002);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2198276,
                column: "Price",
                value: 9.9900000000000002);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3112364,
                column: "Price",
                value: 19.989999999999998);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9931333,
                column: "Price",
                value: 39.990000000000002);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46729005,
                column: "Price",
                value: 19.989999999999998);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 986479331,
                column: "Price",
                value: 35.990000000000002);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 986494972,
                column: "Price",
                value: 49.990000000000002);
        }
    }
}

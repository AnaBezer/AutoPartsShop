using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoPartsShop.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductImageURL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 585064);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2626,
                column: "Description",
                value: "10W-40, 1l, Part Synthetic Oil.              Specification: ACEA A3/B3, API SL, ACEA A3/B4, API CF.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5130,
                column: "Description",
                value: "Tin, Contents: 150ml, Diesel.              OEN P000032 — LIQUI MOLY.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50142,
                columns: new[] { "Description", "ImageURL" },
                values: new object[] { "Front axle, prepared for wear indicator, without accessories.OENs: A0004206600, 0074206520, A0044208920 — MERCEDES-BENZ", "Images/Brakes/1.preview.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 514535,
                columns: new[] { "Description", "ImageURL" },
                values: new object[] { "With seal.              OENs: 5003 968, 1536 304 — MERCEDES-BENZ", "Images/Filters/7preview.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 586624,
                columns: new[] { "Description", "ImageURL" },
                values: new object[] { "Filter Insert.              OENs: L321-14-302, L321-14-302-9A — MERCEDES-BENZ", "Images/Filters/10preview.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 801245,
                columns: new[] { "Description", "ImageURL" },
                values: new object[] { "With seal, Filter Insert.              OENs: 5003 968, 1536 304 — — MERCEDES-BENZ", "Images/Filters/6preview.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2172768,
                column: "Description",
                value: "G11 Blue, 1l.               Specification: G11.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2198276,
                column: "Description",
                value: "5W-40, 1l, Oil Viscosity Classification SAE.              Specification: API SN, ACEA A3/B3, API CF, ACEA A3/B4.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3112364,
                columns: new[] { "Description", "ImageURL" },
                values: new object[] { "42mm, 209mm, 309mm, Filter Insert.              OENs: 5073 968, 1736 304 — MERCEDES-BENZ", "Images/Filters/8preview.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9931333,
                column: "Description",
                value: "Front axle, 390x36mm, 5, slotted/perforated.               Two-piece brake disc, internally vented.              Coated, High-carbon, with bolts/screws.              OENs: A2304211212, 2304211212 — MERCEDES-BENZ");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46729005,
                columns: new[] { "Description", "ImageURL" },
                values: new object[] { "Activated Carbon Filter, 264 mm x 284 mm x 44 mm.              OENs: 5303 968, 1936 304 — — MERCEDES-BENZ", "Images/Filters/9preview.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 986479331,
                column: "Description",
                value: "Rear Axle, 295x28mm, 5x112, Perforated, Vented, Coated, High-carbon.              OEN 839 615 301, 175 615 301 — MERCEDES-BENZ");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 986494972,
                column: "Description",
                value: "Rear Axle, Low-Metallic, with anti-squeak plate, with mounting manual.              OENs: A 001 420 01 20, 001 420 01 20.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2626,
                column: "Description",
                value: "10W-40, 1l, Part Synthetic Oil, Specification: ACEA A3/B3, API SL, ACEA A3/B4, API CF.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5130,
                column: "Description",
                value: "Tin, Contents: 150ml, Diesel, OEN P000032 — LIQUI MOLY.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50142,
                columns: new[] { "Description", "ImageURL" },
                values: new object[] { "Front axle, prepared for wear indicator, without accessories, OENs: A0004206600, 0074206520, A0044208920 — MERCEDES-BENZ", "Images/Brakes/1preview.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 514535,
                columns: new[] { "Description", "ImageURL" },
                values: new object[] { "with seal, OENs: 5003 968, 1536 304 — — MERCEDES-BENZ", "Images/Filters/6preview.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 586624,
                columns: new[] { "Description", "ImageURL" },
                values: new object[] { "Filter Insert, OENs: L321-14-302, L321-14-302-9A — MERCEDES-BENZ", "Images/Filters/9preview.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 801245,
                columns: new[] { "Description", "ImageURL" },
                values: new object[] { "with seal, Filter Insert, OENs: 5003 968, 1536 304 — — MERCEDES-BENZ", "Images/Filters/5preview.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2172768,
                column: "Description",
                value: "G11 Blue, 1l, Specification: G11.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2198276,
                column: "Description",
                value: "5W-40, 1l, Oil Viscosity Classification SAE, Specification: API SN, ACEA A3/B3, API CF, ACEA A3/B4.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3112364,
                columns: new[] { "Description", "ImageURL" },
                values: new object[] { "42mm, 209mm, 309mm, Filter Insert, OENs: 5073 968, 1736 304 — — MERCEDES-BENZ", "Images/Filters/7preview.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9931333,
                column: "Description",
                value: "Front axle, 390x36mm, 5, slotted/perforated, Two-piece brake disc, internally vented, Coated, High-carbon, with bolts/screws, OENs: A2304211212, 2304211212 — MERCEDES-BENZ");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46729005,
                columns: new[] { "Description", "ImageURL" },
                values: new object[] { "Activated Carbon Filter, 264 mm x 284 mm x 44 mm, OENs: 5303 968, 1936 304 — — MERCEDES-BENZ", "Images/Filters/8preview.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 986479331,
                column: "Description",
                value: "Rear Axle, 295x28mm, 5x112, Perforated, Vented, Coated, High-carbon, OEN 839 615 301, 175 615 301 — MERCEDES-BENZ");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 986494972,
                column: "Description",
                value: "Rear Axle, Low-Metallic, with anti-squeak plate, with mounting manual, suitable for MERCEDES-BENZ 190 (W201), OENs: A 001 420 01 20, 001 420 01 20.");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "CategoryId", "Description", "ImageURL", "Price", "ProductName", "Qty" },
                values: new object[] { 585064, "VALEO", 2, "57mm, 77mm, 188mm, Filter Insert, OENs: 8200104272, 1736457304 — MERCEDES-BENZ", "Images/Filters/10preview.jpg", 19.989999999999998, "Air Filter", 50 });
        }
    }
}

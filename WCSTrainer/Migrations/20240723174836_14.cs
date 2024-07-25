using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations {
    /// <inheritdoc />
    public partial class _14 : Migration {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3eb9b095-6da9-45ac-b396-03d852b4e186");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76f9b484-7081-4df3-9d55-648655f2b809");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ca9869d-957b-40a9-bf18-80383dc4b3a1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8c3f7b1d-a6dd-4dc9-ad3d-fc83272bce3a", null, "trainee", "TRAINEE" },
                    { "9de75606-b5c2-4d80-b391-508060f67055", null, "trainer", "TRAINER" },
                    { "f270f6b9-a0eb-4e57-938d-63d3620118b0", null, "admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c3f7b1d-a6dd-4dc9-ad3d-fc83272bce3a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9de75606-b5c2-4d80-b391-508060f67055");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f270f6b9-a0eb-4e57-938d-63d3620118b0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3eb9b095-6da9-45ac-b396-03d852b4e186", null, "admin", "ADMIN" },
                    { "76f9b484-7081-4df3-9d55-648655f2b809", null, "trainee", "TRAINEE" },
                    { "7ca9869d-957b-40a9-bf18-80383dc4b3a1", null, "trainer", "TRAINER" }
                });
        }
    }
}

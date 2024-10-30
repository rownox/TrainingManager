using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations
{
    /// <inheritdoc />
    public partial class _9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingOrders_Locations_LocationId",
                table: "TrainingOrders");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f019bca-54d2-4773-961d-b1d463c52d4e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c94c4a49-9277-4aba-b4c1-2259653f7467");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd2fb9f0-28dc-41e6-8806-63d685e25ac8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f517db22-3dc2-4942-959e-78709f9a531b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "66005c92-8796-4788-979d-0e12f5b4e03c", null, "guest", "GUEST" },
                    { "69d1cbb2-21a7-4a09-8c89-7e4d3b0e229a", null, "admin", "ADMIN" },
                    { "9dbbb657-e0ef-4428-83a9-32a21d138819", null, "owner", "OWNER" },
                    { "a93f0e9c-e81d-4f33-9da4-3577aae37642", null, "user", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingOrders_Locations_LocationId",
                table: "TrainingOrders",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingOrders_Locations_LocationId",
                table: "TrainingOrders");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66005c92-8796-4788-979d-0e12f5b4e03c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69d1cbb2-21a7-4a09-8c89-7e4d3b0e229a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9dbbb657-e0ef-4428-83a9-32a21d138819");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a93f0e9c-e81d-4f33-9da4-3577aae37642");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5f019bca-54d2-4773-961d-b1d463c52d4e", null, "guest", "GUEST" },
                    { "c94c4a49-9277-4aba-b4c1-2259653f7467", null, "user", "USER" },
                    { "cd2fb9f0-28dc-41e6-8806-63d685e25ac8", null, "admin", "ADMIN" },
                    { "f517db22-3dc2-4942-959e-78709f9a531b", null, "owner", "OWNER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingOrders_Locations_LocationId",
                table: "TrainingOrders",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5c5bfe-e64f-4893-810a-01b173346eeb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f397ca0-aa03-4196-97d2-451394c9c6f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4f2c5b5-7080-45f7-919d-3b6c613d0fee");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "TrainingOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "259c0bec-0a6e-44bf-997a-35874f67561e", null, "trainer", "TRAINER" },
                    { "7ae9f6b2-e001-494d-8194-8f807ffa977f", null, "admin", "ADMIN" },
                    { "e05d2563-9c20-4752-aca6-a6262bae3d64", null, "trainee", "TRAINEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "259c0bec-0a6e-44bf-997a-35874f67561e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ae9f6b2-e001-494d-8194-8f807ffa977f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e05d2563-9c20-4752-aca6-a6262bae3d64");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "TrainingOrders");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c5c5bfe-e64f-4893-810a-01b173346eeb", null, "trainer", "TRAINER" },
                    { "9f397ca0-aa03-4196-97d2-451394c9c6f6", null, "admin", "ADMIN" },
                    { "c4f2c5b5-7080-45f7-919d-3b6c613d0fee", null, "trainee", "TRAINEE" }
                });
        }
    }
}

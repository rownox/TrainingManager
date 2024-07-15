using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations
{
    /// <inheritdoc />
    public partial class _10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02457c7e-166d-49b9-8de5-b114ac994d97");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c294e7a3-1c42-46c2-bfbd-6cf8646b3531");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb74c87c-e2d9-4e01-8317-e3c640c7d1ee");

            migrationBuilder.AlterColumn<string>(
                name: "TrainerIds",
                table: "TrainingOrders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ac4e7409-d44b-4524-9b67-acbfc2ac654d", null, "admin", "ADMIN" },
                    { "d2ce2e80-6990-4c6f-8810-2fdc85a1bfcc", null, "trainer", "TRAINER" },
                    { "ec4fa17c-e609-4636-9d3f-cf1f810e00b9", null, "trainee", "TRAINEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac4e7409-d44b-4524-9b67-acbfc2ac654d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2ce2e80-6990-4c6f-8810-2fdc85a1bfcc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec4fa17c-e609-4636-9d3f-cf1f810e00b9");

            migrationBuilder.AlterColumn<string>(
                name: "TrainerIds",
                table: "TrainingOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02457c7e-166d-49b9-8de5-b114ac994d97", null, "admin", "ADMIN" },
                    { "c294e7a3-1c42-46c2-bfbd-6cf8646b3531", null, "trainee", "TRAINEE" },
                    { "eb74c87c-e2d9-4e01-8317-e3c640c7d1ee", null, "trainer", "TRAINER" }
                });
        }
    }
}

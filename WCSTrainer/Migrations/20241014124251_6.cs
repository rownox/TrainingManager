using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations
{
    /// <inheritdoc />
    public partial class _6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37ea2d51-b749-43b4-80e7-93167ec24668");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58c0029b-7af8-4050-b5dc-f0148a577760");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df6a3d51-abed-40b8-ba30-6e84d4f83e9c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "553110f3-dac1-4bbe-9815-6fdb0358042a", null, "admin", "ADMIN" },
                    { "999de91f-aa6a-45ca-8e7c-939e0ec8c320", null, "guest", "GUEST" },
                    { "eced5181-4e27-4989-8378-f84a8da0492c", null, "user", "USER" },
                    { "fcfa4778-8c8c-4a16-800b-317ef7d5816d", null, "owner", "OWNER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "553110f3-dac1-4bbe-9815-6fdb0358042a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "999de91f-aa6a-45ca-8e7c-939e0ec8c320");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eced5181-4e27-4989-8378-f84a8da0492c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fcfa4778-8c8c-4a16-800b-317ef7d5816d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "37ea2d51-b749-43b4-80e7-93167ec24668", null, "trainee", "TRAINEE" },
                    { "58c0029b-7af8-4050-b5dc-f0148a577760", null, "admin", "ADMIN" },
                    { "df6a3d51-abed-40b8-ba30-6e84d4f83e9c", null, "trainer", "TRAINER" }
                });
        }
    }
}

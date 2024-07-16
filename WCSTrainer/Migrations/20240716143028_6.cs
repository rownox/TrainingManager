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
                keyValue: "0c69eb24-b1e2-401f-8dac-2259a653be06");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a256f1d-a537-4a69-88ee-ee64f744a120");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c925ed9a-0ce4-4b38-8b55-2270e8155be3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a54bb44f-1c60-46e6-9b1e-9e926a92791e", null, "trainer", "TRAINER" },
                    { "ba6baa2a-63c3-4f6e-862c-688323964391", null, "admin", "ADMIN" },
                    { "f64c5de4-3afa-4f7e-8a0b-81905c011766", null, "trainee", "TRAINEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a54bb44f-1c60-46e6-9b1e-9e926a92791e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba6baa2a-63c3-4f6e-862c-688323964391");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f64c5de4-3afa-4f7e-8a0b-81905c011766");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0c69eb24-b1e2-401f-8dac-2259a653be06", null, "trainer", "TRAINER" },
                    { "3a256f1d-a537-4a69-88ee-ee64f744a120", null, "trainee", "TRAINEE" },
                    { "c925ed9a-0ce4-4b38-8b55-2270e8155be3", null, "admin", "ADMIN" }
                });
        }
    }
}

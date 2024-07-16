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
                keyValue: "51e7a3de-d8be-4d77-8d39-6ce63d34bffa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c8fab66-770c-4c11-a8e0-68e9d15233d4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9306be7f-ffe7-44f9-b4fa-1acb5eae39e7");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Skills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8a2e064c-3ef7-42fc-a1ea-d59e8162f5f5", null, "admin", "ADMIN" },
                    { "b91d47fa-059b-44b3-b462-aaabcc7dda44", null, "trainer", "TRAINER" },
                    { "fcae061f-862e-495c-a78e-d41dff596e06", null, "trainee", "TRAINEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a2e064c-3ef7-42fc-a1ea-d59e8162f5f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b91d47fa-059b-44b3-b462-aaabcc7dda44");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fcae061f-862e-495c-a78e-d41dff596e06");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Skills");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "51e7a3de-d8be-4d77-8d39-6ce63d34bffa", null, "trainee", "TRAINEE" },
                    { "7c8fab66-770c-4c11-a8e0-68e9d15233d4", null, "trainer", "TRAINER" },
                    { "9306be7f-ffe7-44f9-b4fa-1acb5eae39e7", null, "admin", "ADMIN" }
                });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48708268-7ddd-4186-bf9e-3228fe49b358");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95a9b3b2-d72d-45b2-aecf-aadeb0ac146e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b318f1b8-4ca8-47be-a721-1388221dbed8");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TrainingOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Description",
                table: "TrainingOrders");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "48708268-7ddd-4186-bf9e-3228fe49b358", null, "trainer", "TRAINER" },
                    { "95a9b3b2-d72d-45b2-aecf-aadeb0ac146e", null, "admin", "ADMIN" },
                    { "b318f1b8-4ca8-47be-a721-1388221dbed8", null, "trainee", "TRAINEE" }
                });
        }
    }
}

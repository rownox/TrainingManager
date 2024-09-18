using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations
{
    /// <inheritdoc />
    public partial class _5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25b381c7-2e76-4cee-96aa-6e8781773d84");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4bb07a97-352f-4afd-a998-0adf40eece7d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56021199-eccb-4d65-8953-a1198ffd53d0");

            migrationBuilder.AddColumn<bool>(
                name: "Archived",
                table: "TrainingOrders",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Archived",
                table: "TrainingOrders");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "25b381c7-2e76-4cee-96aa-6e8781773d84", null, "trainer", "TRAINER" },
                    { "4bb07a97-352f-4afd-a998-0adf40eece7d", null, "trainee", "TRAINEE" },
                    { "56021199-eccb-4d65-8953-a1198ffd53d0", null, "admin", "ADMIN" }
                });
        }
    }
}

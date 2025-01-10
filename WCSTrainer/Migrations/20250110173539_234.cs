using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations
{
    /// <inheritdoc />
    public partial class _234 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09c0c7ba-27e6-4f98-88b1-19c27395eb07");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5fc7c210-a365-4a4b-8ad3-c436cfb9dc62");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8acd1cff-add8-458a-ae23-fbd8988acbc0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "acafc2b4-dc9e-4eb6-96a3-a642c041152f");

            migrationBuilder.AddColumn<string>(
                name: "Certificate",
                table: "TrainingOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "04273020-5231-4192-860c-54d5ee6e4da8", null, "guest", "GUEST" },
                    { "37cccabc-f85a-48e1-93e3-0317de8b8c96", null, "admin", "ADMIN" },
                    { "56f82c90-750a-4615-b2e8-b2af60a8cdac", null, "user", "USER" },
                    { "6475daf6-1c02-47c4-88d9-07d8771da02c", null, "owner", "OWNER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04273020-5231-4192-860c-54d5ee6e4da8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37cccabc-f85a-48e1-93e3-0317de8b8c96");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56f82c90-750a-4615-b2e8-b2af60a8cdac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6475daf6-1c02-47c4-88d9-07d8771da02c");

            migrationBuilder.DropColumn(
                name: "Certificate",
                table: "TrainingOrders");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "09c0c7ba-27e6-4f98-88b1-19c27395eb07", null, "guest", "GUEST" },
                    { "5fc7c210-a365-4a4b-8ad3-c436cfb9dc62", null, "owner", "OWNER" },
                    { "8acd1cff-add8-458a-ae23-fbd8988acbc0", null, "user", "USER" },
                    { "acafc2b4-dc9e-4eb6-96a3-a642c041152f", null, "admin", "ADMIN" }
                });
        }
    }
}

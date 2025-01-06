using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations
{
    /// <inheritdoc />
    public partial class _543 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "238cb15b-e449-49bc-8af4-ccb4d1dcdf81");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "342bb0ba-589c-4d37-ba97-ebef4b49e639");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c65f342-8200-4aaa-a035-d483621f5f8a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a49fd6b-098a-4a40-afcb-1c71f9e851e3");

            migrationBuilder.AddColumn<string>(
                name: "ClosedByUserId",
                table: "TrainingOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClosingSignature",
                table: "TrainingOrders",
                type: "nvarchar(max)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ClosedByUserId",
                table: "TrainingOrders");

            migrationBuilder.DropColumn(
                name: "ClosingSignature",
                table: "TrainingOrders");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "238cb15b-e449-49bc-8af4-ccb4d1dcdf81", null, "user", "USER" },
                    { "342bb0ba-589c-4d37-ba97-ebef4b49e639", null, "admin", "ADMIN" },
                    { "4c65f342-8200-4aaa-a035-d483621f5f8a", null, "owner", "OWNER" },
                    { "5a49fd6b-098a-4a40-afcb-1c71f9e851e3", null, "guest", "GUEST" }
                });
        }
    }
}

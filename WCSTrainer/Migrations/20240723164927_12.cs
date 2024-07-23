using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations
{
    /// <inheritdoc />
    public partial class _12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93afec21-9606-4bc9-8851-b290c5eb2df8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a57e68a1-d5ef-4192-993e-98e6d5589863");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6a97a0d-f0c9-40f9-b9da-114ed3aa83ce");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "TrainingOrders",
                newName: "CompletionDate");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "57f903e1-2105-4825-80a4-d08572c1ee6a", null, "trainee", "TRAINEE" },
                    { "81fbc576-ecca-4d1f-9f6a-4d5ad0459aa8", null, "trainer", "TRAINER" },
                    { "87d0517b-c6c7-44d4-8819-800edcb7b658", null, "admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57f903e1-2105-4825-80a4-d08572c1ee6a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81fbc576-ecca-4d1f-9f6a-4d5ad0459aa8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87d0517b-c6c7-44d4-8819-800edcb7b658");

            migrationBuilder.RenameColumn(
                name: "CompletionDate",
                table: "TrainingOrders",
                newName: "EndDate");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "93afec21-9606-4bc9-8851-b290c5eb2df8", null, "trainer", "TRAINER" },
                    { "a57e68a1-d5ef-4192-993e-98e6d5589863", null, "trainee", "TRAINEE" },
                    { "d6a97a0d-f0c9-40f9-b9da-114ed3aa83ce", null, "admin", "ADMIN" }
                });
        }
    }
}

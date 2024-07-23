using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations
{
    /// <inheritdoc />
    public partial class _13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Priority",
                table: "TrainingOrders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "CompletionDate",
                table: "TrainingOrders",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "BeginDate",
                table: "TrainingOrders",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3eb9b095-6da9-45ac-b396-03d852b4e186", null, "admin", "ADMIN" },
                    { "76f9b484-7081-4df3-9d55-648655f2b809", null, "trainee", "TRAINEE" },
                    { "7ca9869d-957b-40a9-bf18-80383dc4b3a1", null, "trainer", "TRAINER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3eb9b095-6da9-45ac-b396-03d852b4e186");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76f9b484-7081-4df3-9d55-648655f2b809");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ca9869d-957b-40a9-bf18-80383dc4b3a1");

            migrationBuilder.AlterColumn<string>(
                name: "Priority",
                table: "TrainingOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "CompletionDate",
                table: "TrainingOrders",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "BeginDate",
                table: "TrainingOrders",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

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
    }
}

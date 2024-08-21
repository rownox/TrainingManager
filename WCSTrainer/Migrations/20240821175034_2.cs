using System;
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
                keyValue: "1cba9ae0-a27a-423f-be0e-0f80ef23a52f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1157900-95de-4d40-a56d-1828733e1a3f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fcd025c7-0504-4c0a-9167-9a372748e224");

            migrationBuilder.AddColumn<DateOnly>(
                name: "ApprovalDate",
                table: "TrainingOrders",
                type: "date",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c5c5bfe-e64f-4893-810a-01b173346eeb", null, "trainer", "TRAINER" },
                    { "9f397ca0-aa03-4196-97d2-451394c9c6f6", null, "admin", "ADMIN" },
                    { "c4f2c5b5-7080-45f7-919d-3b6c613d0fee", null, "trainee", "TRAINEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5c5bfe-e64f-4893-810a-01b173346eeb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f397ca0-aa03-4196-97d2-451394c9c6f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4f2c5b5-7080-45f7-919d-3b6c613d0fee");

            migrationBuilder.DropColumn(
                name: "ApprovalDate",
                table: "TrainingOrders");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1cba9ae0-a27a-423f-be0e-0f80ef23a52f", null, "trainer", "TRAINER" },
                    { "a1157900-95de-4d40-a56d-1828733e1a3f", null, "admin", "ADMIN" },
                    { "fcd025c7-0504-4c0a-9167-9a372748e224", null, "trainee", "TRAINEE" }
                });
        }
    }
}

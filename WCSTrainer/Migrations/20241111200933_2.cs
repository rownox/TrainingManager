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
                keyValue: "a12383c7-2936-44f3-88ad-c006065fe8de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7d49518-2ebf-408e-ad21-f9fc2d1326e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1fc36af-d903-4543-a5d2-f6bca3070bf9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eaaf10bf-3bd8-4148-9739-179cae63f301");

            migrationBuilder.AddColumn<DateOnly>(
                name: "ScheduleDate",
                table: "TrainingOrders",
                type: "date",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "09d69418-c9ee-4e32-850d-4cfaf497e117", null, "owner", "OWNER" },
                    { "71cd46ae-1ae7-47da-bec5-400a11473868", null, "user", "USER" },
                    { "d0e6c78e-17b9-407c-b229-c28893ebdd8c", null, "admin", "ADMIN" },
                    { "d4ca1824-2ffa-4c64-87f5-777d705967a3", null, "guest", "GUEST" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09d69418-c9ee-4e32-850d-4cfaf497e117");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71cd46ae-1ae7-47da-bec5-400a11473868");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0e6c78e-17b9-407c-b229-c28893ebdd8c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4ca1824-2ffa-4c64-87f5-777d705967a3");

            migrationBuilder.DropColumn(
                name: "ScheduleDate",
                table: "TrainingOrders");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a12383c7-2936-44f3-88ad-c006065fe8de", null, "owner", "OWNER" },
                    { "a7d49518-2ebf-408e-ad21-f9fc2d1326e0", null, "guest", "GUEST" },
                    { "b1fc36af-d903-4543-a5d2-f6bca3070bf9", null, "admin", "ADMIN" },
                    { "eaaf10bf-3bd8-4148-9739-179cae63f301", null, "user", "USER" }
                });
        }
    }
}

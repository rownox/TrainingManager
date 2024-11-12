using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations
{
    /// <inheritdoc />
    public partial class _10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66005c92-8796-4788-979d-0e12f5b4e03c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69d1cbb2-21a7-4a09-8c89-7e4d3b0e229a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9dbbb657-e0ef-4428-83a9-32a21d138819");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a93f0e9c-e81d-4f33-9da4-3577aae37642");

            migrationBuilder.AddColumn<DateOnly>(
                name: "ScheduleDate",
                table: "TrainingOrders",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SkillCategoryId",
                table: "Skills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LessonCategoryId",
                table: "Lessons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LessonCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SkillCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillCategories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0ca18724-838e-4439-a71c-656833aa4471", null, "user", "USER" },
                    { "a19bbb47-4632-43e1-8fb0-407bf51e1b5b", null, "admin", "ADMIN" },
                    { "f2a1f15c-4312-47fb-8068-191cfdf7ce61", null, "guest", "GUEST" },
                    { "fc596f17-69bd-4dde-bebe-32823ca1464f", null, "owner", "OWNER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skills_SkillCategoryId",
                table: "Skills",
                column: "SkillCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_LessonCategoryId",
                table: "Lessons",
                column: "LessonCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_LessonCategories_LessonCategoryId",
                table: "Lessons",
                column: "LessonCategoryId",
                principalTable: "LessonCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_SkillCategories_SkillCategoryId",
                table: "Skills",
                column: "SkillCategoryId",
                principalTable: "SkillCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_LessonCategories_LessonCategoryId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_SkillCategories_SkillCategoryId",
                table: "Skills");

            migrationBuilder.DropTable(
                name: "LessonCategories");

            migrationBuilder.DropTable(
                name: "SkillCategories");

            migrationBuilder.DropIndex(
                name: "IX_Skills_SkillCategoryId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_LessonCategoryId",
                table: "Lessons");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ca18724-838e-4439-a71c-656833aa4471");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a19bbb47-4632-43e1-8fb0-407bf51e1b5b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2a1f15c-4312-47fb-8068-191cfdf7ce61");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc596f17-69bd-4dde-bebe-32823ca1464f");

            migrationBuilder.DropColumn(
                name: "ScheduleDate",
                table: "TrainingOrders");

            migrationBuilder.DropColumn(
                name: "SkillCategoryId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "LessonCategoryId",
                table: "Lessons");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "66005c92-8796-4788-979d-0e12f5b4e03c", null, "guest", "GUEST" },
                    { "69d1cbb2-21a7-4a09-8c89-7e4d3b0e229a", null, "admin", "ADMIN" },
                    { "9dbbb657-e0ef-4428-83a9-32a21d138819", null, "owner", "OWNER" },
                    { "a93f0e9c-e81d-4f33-9da4-3577aae37642", null, "user", "USER" }
                });
        }
    }
}

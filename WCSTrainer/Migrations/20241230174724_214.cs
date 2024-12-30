using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations
{
    /// <inheritdoc />
    public partial class _214 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Descriptions_FileUpload_FileUploadId",
                table: "Descriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Descriptions_Lessons_LessonId",
                table: "Descriptions");

            migrationBuilder.DropTable(
                name: "FileUpload");

            migrationBuilder.DropIndex(
                name: "IX_Descriptions_FileUploadId",
                table: "Descriptions");

            migrationBuilder.DropIndex(
                name: "IX_Descriptions_LessonId",
                table: "Descriptions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2617a011-b3fc-40d3-879a-cf53f12ddc34");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64b4121d-9844-4ed5-9595-72dcbf146183");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75a9d20e-e4ed-4789-b7bb-7a5a267760fb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f647c8a9-78e3-4295-8dda-6f118ea9f8e5");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "Descriptions");

            migrationBuilder.DropColumn(
                name: "FileUploadId",
                table: "Descriptions");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "Descriptions");

            migrationBuilder.AddColumn<int>(
                name: "DescriptionId",
                table: "Lessons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "836c03dd-edc5-4966-afad-4bc368b5a722", null, "guest", "GUEST" },
                    { "b265e947-2ec2-492b-998c-61dad7622c28", null, "owner", "OWNER" },
                    { "e020cf3b-6384-4c2f-b641-6010653f5528", null, "user", "USER" },
                    { "f88bedf7-3105-492c-8b77-2806d7124162", null, "admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_DescriptionId",
                table: "Lessons",
                column: "DescriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Descriptions_DescriptionId",
                table: "Lessons",
                column: "DescriptionId",
                principalTable: "Descriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Descriptions_DescriptionId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_DescriptionId",
                table: "Lessons");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "836c03dd-edc5-4966-afad-4bc368b5a722");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b265e947-2ec2-492b-998c-61dad7622c28");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e020cf3b-6384-4c2f-b641-6010653f5528");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f88bedf7-3105-492c-8b77-2806d7124162");

            migrationBuilder.DropColumn(
                name: "DescriptionId",
                table: "Lessons");

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "Descriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FileUploadId",
                table: "Descriptions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LessonId",
                table: "Descriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FileUpload",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileUpload", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2617a011-b3fc-40d3-879a-cf53f12ddc34", null, "owner", "OWNER" },
                    { "64b4121d-9844-4ed5-9595-72dcbf146183", null, "guest", "GUEST" },
                    { "75a9d20e-e4ed-4789-b7bb-7a5a267760fb", null, "admin", "ADMIN" },
                    { "f647c8a9-78e3-4295-8dda-6f118ea9f8e5", null, "user", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Descriptions_FileUploadId",
                table: "Descriptions",
                column: "FileUploadId");

            migrationBuilder.CreateIndex(
                name: "IX_Descriptions_LessonId",
                table: "Descriptions",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Descriptions_FileUpload_FileUploadId",
                table: "Descriptions",
                column: "FileUploadId",
                principalTable: "FileUpload",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Descriptions_Lessons_LessonId",
                table: "Descriptions",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Descriptions_ImageUpload_ImageUploadId",
                table: "Descriptions");

            migrationBuilder.DropTable(
                name: "ImageUpload");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cc2e97d-2d7a-45a9-a0e1-e7cc57ae46a3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6022a93d-6787-4e3c-b074-69bcfae8b4d6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abb18395-e7ed-4a2c-bf44-b8b054747211");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d757eb15-2ed3-4309-b455-ee1939703723");

            migrationBuilder.DropColumn(
                name: "DescriptionType",
                table: "Descriptions");

            migrationBuilder.RenameColumn(
                name: "ImageUploadId",
                table: "Descriptions",
                newName: "FileUploadId");

            migrationBuilder.RenameIndex(
                name: "IX_Descriptions_ImageUploadId",
                table: "Descriptions",
                newName: "IX_Descriptions_FileUploadId");

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
                    { "2e9835d9-28a4-4d4a-a032-bdd414350f31", null, "guest", "GUEST" },
                    { "bca33435-dcde-43cf-a9a7-7d8af1abb27f", null, "owner", "OWNER" },
                    { "db302c8f-4b33-483e-9367-32864bae109e", null, "admin", "ADMIN" },
                    { "e4af9743-4b8c-4a3b-a611-a58415ac09e3", null, "user", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Descriptions_FileUpload_FileUploadId",
                table: "Descriptions",
                column: "FileUploadId",
                principalTable: "FileUpload",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Descriptions_FileUpload_FileUploadId",
                table: "Descriptions");

            migrationBuilder.DropTable(
                name: "FileUpload");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e9835d9-28a4-4d4a-a032-bdd414350f31");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bca33435-dcde-43cf-a9a7-7d8af1abb27f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db302c8f-4b33-483e-9367-32864bae109e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4af9743-4b8c-4a3b-a611-a58415ac09e3");

            migrationBuilder.RenameColumn(
                name: "FileUploadId",
                table: "Descriptions",
                newName: "ImageUploadId");

            migrationBuilder.RenameIndex(
                name: "IX_Descriptions_FileUploadId",
                table: "Descriptions",
                newName: "IX_Descriptions_ImageUploadId");

            migrationBuilder.AddColumn<int>(
                name: "DescriptionType",
                table: "Descriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ImageUpload",
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
                    table.PrimaryKey("PK_ImageUpload", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4cc2e97d-2d7a-45a9-a0e1-e7cc57ae46a3", null, "admin", "ADMIN" },
                    { "6022a93d-6787-4e3c-b074-69bcfae8b4d6", null, "guest", "GUEST" },
                    { "abb18395-e7ed-4a2c-bf44-b8b054747211", null, "owner", "OWNER" },
                    { "d757eb15-2ed3-4309-b455-ee1939703723", null, "user", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Descriptions_ImageUpload_ImageUploadId",
                table: "Descriptions",
                column: "ImageUploadId",
                principalTable: "ImageUpload",
                principalColumn: "Id");
        }
    }
}

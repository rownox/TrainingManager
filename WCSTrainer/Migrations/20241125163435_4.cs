using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations
{
    /// <inheritdoc />
    public partial class _4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: "06988f7e-8e55-405c-b14d-93fcbcfca878");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c46252c-a235-4249-95e5-4b06c5c11727");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc60c116-8b65-459f-8eaf-0d4ba2112c6d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5eb4779-0694-4412-a52c-f69a84d30999");

            migrationBuilder.DropColumn(
                name: "DescriptionId",
                table: "Lessons");

            migrationBuilder.RenameColumn(
                name: "PageId",
                table: "Descriptions",
                newName: "LessonId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "49376fa8-8a03-4cda-8a22-b88e61abc37c", null, "user", "USER" },
                    { "c0af030f-84a9-4891-8efe-e38356cc4481", null, "admin", "ADMIN" },
                    { "c8e784b7-7bc0-46bd-8c39-5d0cbe7b7129", null, "owner", "OWNER" },
                    { "fd692f8d-173d-4125-b022-93315fab7c55", null, "guest", "GUEST" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Descriptions_LessonId",
                table: "Descriptions",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Descriptions_Lessons_LessonId",
                table: "Descriptions",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Descriptions_Lessons_LessonId",
                table: "Descriptions");

            migrationBuilder.DropIndex(
                name: "IX_Descriptions_LessonId",
                table: "Descriptions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49376fa8-8a03-4cda-8a22-b88e61abc37c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0af030f-84a9-4891-8efe-e38356cc4481");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8e784b7-7bc0-46bd-8c39-5d0cbe7b7129");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd692f8d-173d-4125-b022-93315fab7c55");

            migrationBuilder.RenameColumn(
                name: "LessonId",
                table: "Descriptions",
                newName: "PageId");

            migrationBuilder.AddColumn<int>(
                name: "DescriptionId",
                table: "Lessons",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06988f7e-8e55-405c-b14d-93fcbcfca878", null, "admin", "ADMIN" },
                    { "6c46252c-a235-4249-95e5-4b06c5c11727", null, "user", "USER" },
                    { "bc60c116-8b65-459f-8eaf-0d4ba2112c6d", null, "owner", "OWNER" },
                    { "f5eb4779-0694-4412-a52c-f69a84d30999", null, "guest", "GUEST" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_DescriptionId",
                table: "Lessons",
                column: "DescriptionId",
                unique: true,
                filter: "[DescriptionId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Descriptions_DescriptionId",
                table: "Lessons",
                column: "DescriptionId",
                principalTable: "Descriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations
{
    /// <inheritdoc />
    public partial class _562 : Migration
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

            migrationBuilder.AddColumn<int>(
                name: "LessonId",
                table: "Descriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5eb1b639-7f08-4ef7-a4a0-bfc2a0e5ee22", null, "guest", "GUEST" },
                    { "99ba7a4c-dc67-4223-96ce-6a18c2770631", null, "admin", "ADMIN" },
                    { "e1759d49-0fce-4bf9-89a2-f964c9686133", null, "owner", "OWNER" },
                    { "f8024a30-adfe-43fc-ad5f-a8996c20f6ab", null, "user", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Descriptions_LessonId",
                table: "Descriptions",
                column: "LessonId",
                unique: true);

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
                keyValue: "5eb1b639-7f08-4ef7-a4a0-bfc2a0e5ee22");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99ba7a4c-dc67-4223-96ce-6a18c2770631");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1759d49-0fce-4bf9-89a2-f964c9686133");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8024a30-adfe-43fc-ad5f-a8996c20f6ab");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "Descriptions");

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
    }
}

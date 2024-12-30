using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations
{
    /// <inheritdoc />
    public partial class _235 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Descriptions");

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
                name: "DescriptionId",
                table: "Lessons");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Lessons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Lessons");

            migrationBuilder.AddColumn<int>(
                name: "DescriptionId",
                table: "Lessons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Descriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    TextContent = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Descriptions_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
        }
    }
}

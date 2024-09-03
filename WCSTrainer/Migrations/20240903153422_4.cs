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
            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "259c0bec-0a6e-44bf-997a-35874f67561e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ae9f6b2-e001-494d-8194-8f807ffa977f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e05d2563-9c20-4752-aca6-a6262bae3d64");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "TrainingOrders");

            migrationBuilder.AddColumn<int>(
                name: "LessonId",
                table: "TrainingOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingOrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_TrainingOrders_TrainingOrderId",
                        column: x => x.TrainingOrderId,
                        principalTable: "TrainingOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "75ce5d99-f255-4bdd-939e-f21813840673", null, "trainee", "TRAINEE" },
                    { "88849c53-ba1f-44c4-96e1-a9d067e6e4c8", null, "admin", "ADMIN" },
                    { "9c90f352-accd-455d-9bf4-7fde1eae65d5", null, "trainer", "TRAINER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_TrainingOrderId",
                table: "Lessons",
                column: "TrainingOrderId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75ce5d99-f255-4bdd-939e-f21813840673");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88849c53-ba1f-44c4-96e1-a9d067e6e4c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c90f352-accd-455d-9bf4-7fde1eae65d5");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "TrainingOrders");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TrainingOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Groups = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hours = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "259c0bec-0a6e-44bf-997a-35874f67561e", null, "trainer", "TRAINER" },
                    { "7ae9f6b2-e001-494d-8194-8f807ffa977f", null, "admin", "ADMIN" },
                    { "e05d2563-9c20-4752-aca6-a6262bae3d64", null, "trainee", "TRAINEE" }
                });
        }
    }
}

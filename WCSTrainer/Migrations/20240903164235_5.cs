using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations
{
    /// <inheritdoc />
    public partial class _5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_TrainingOrders_TrainingOrderId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_TrainingOrderId",
                table: "Lessons");

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
                name: "TrainingOrderId",
                table: "Lessons");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8c6dcbe7-bc8b-4417-a76d-c0c79f45c79c", null, "trainee", "TRAINEE" },
                    { "caad8ec3-93f0-4ecf-a641-2a98dbe9fd75", null, "trainer", "TRAINER" },
                    { "ec0e96f5-3fe2-4fac-8205-cb8fc344fb2f", null, "admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingOrders_LessonId",
                table: "TrainingOrders",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingOrders_Lessons_LessonId",
                table: "TrainingOrders",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingOrders_Lessons_LessonId",
                table: "TrainingOrders");

            migrationBuilder.DropIndex(
                name: "IX_TrainingOrders_LessonId",
                table: "TrainingOrders");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c6dcbe7-bc8b-4417-a76d-c0c79f45c79c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "caad8ec3-93f0-4ecf-a641-2a98dbe9fd75");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec0e96f5-3fe2-4fac-8205-cb8fc344fb2f");

            migrationBuilder.AddColumn<int>(
                name: "TrainingOrderId",
                table: "Lessons",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_TrainingOrders_TrainingOrderId",
                table: "Lessons",
                column: "TrainingOrderId",
                principalTable: "TrainingOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

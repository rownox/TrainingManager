using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations {
   /// <inheritdoc />
   public partial class _4 : Migration {
      /// <inheritdoc />
      protected override void Up(MigrationBuilder migrationBuilder) {
         migrationBuilder.DropForeignKey(
             name: "FK_TrainingOrders_Skills_SkillId",
             table: "TrainingOrders");

         migrationBuilder.DropIndex(
             name: "IX_TrainingOrders_SkillId",
             table: "TrainingOrders");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "8a2e064c-3ef7-42fc-a1ea-d59e8162f5f5");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "b91d47fa-059b-44b3-b462-aaabcc7dda44");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "fcae061f-862e-495c-a78e-d41dff596e06");

         migrationBuilder.DropColumn(
             name: "SkillId",
             table: "TrainingOrders");

         migrationBuilder.CreateTable(
             name: "TrainingOrderSkill",
             columns: table => new {
                SkillId = table.Column<int>(type: "int", nullable: false),
                TrainingOrderId = table.Column<int>(type: "int", nullable: false)
             },
             constraints: table => {
                table.PrimaryKey("PK_TrainingOrderSkill", x => new { x.SkillId, x.TrainingOrderId });
                table.ForeignKey(
                       name: "FK_TrainingOrderSkill_Skills_SkillId",
                       column: x => x.SkillId,
                       principalTable: "Skills",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                       name: "FK_TrainingOrderSkill_TrainingOrders_TrainingOrderId",
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
                    { "4ca30a03-9265-40be-bc12-602684d4d000", null, "admin", "ADMIN" },
                    { "5383132b-ad80-4b51-9f10-a3dbd9283fda", null, "trainee", "TRAINEE" },
                    { "8678b72c-6502-434f-bca6-1843b4b10079", null, "trainer", "TRAINER" }
             });

         migrationBuilder.CreateIndex(
             name: "IX_TrainingOrderSkill_TrainingOrderId",
             table: "TrainingOrderSkill",
             column: "TrainingOrderId");
      }

      /// <inheritdoc />
      protected override void Down(MigrationBuilder migrationBuilder) {
         migrationBuilder.DropTable(
             name: "TrainingOrderSkill");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "4ca30a03-9265-40be-bc12-602684d4d000");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "5383132b-ad80-4b51-9f10-a3dbd9283fda");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "8678b72c-6502-434f-bca6-1843b4b10079");

         migrationBuilder.AddColumn<int>(
             name: "SkillId",
             table: "TrainingOrders",
             type: "int",
             nullable: false,
             defaultValue: 0);

         migrationBuilder.InsertData(
             table: "AspNetRoles",
             columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
             values: new object[,]
             {
                    { "8a2e064c-3ef7-42fc-a1ea-d59e8162f5f5", null, "admin", "ADMIN" },
                    { "b91d47fa-059b-44b3-b462-aaabcc7dda44", null, "trainer", "TRAINER" },
                    { "fcae061f-862e-495c-a78e-d41dff596e06", null, "trainee", "TRAINEE" }
             });

         migrationBuilder.CreateIndex(
             name: "IX_TrainingOrders_SkillId",
             table: "TrainingOrders",
             column: "SkillId");

         migrationBuilder.AddForeignKey(
             name: "FK_TrainingOrders_Skills_SkillId",
             table: "TrainingOrders",
             column: "SkillId",
             principalTable: "Skills",
             principalColumn: "Id",
             onDelete: ReferentialAction.Cascade);
      }
   }
}

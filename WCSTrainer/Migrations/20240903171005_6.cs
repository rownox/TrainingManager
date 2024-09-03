using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations
{
    /// <inheritdoc />
    public partial class _6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AspNetUsers_UserAccountId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerGroupEmployees_Employees_TrainersId",
                table: "TrainerGroupEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerGroupEmployees_TrainerGroups_TrainerGroupId",
                table: "TrainerGroupEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerTrainingOrders_Employees_TrainersId",
                table: "TrainerTrainingOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerTrainingOrders_TrainingOrders_TrainingOrdersAsTrainerId",
                table: "TrainerTrainingOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingOrderTrainerGroups_TrainerGroups_TrainerGroupsId",
                table: "TrainingOrderTrainerGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingOrderTrainerGroups_TrainingOrders_TrainingOrdersId",
                table: "TrainingOrderTrainerGroups");

            migrationBuilder.DropTable(
                name: "TrainingOrderSkill");

            migrationBuilder.DropIndex(
                name: "IX_Employees_UserAccountId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingOrderTrainerGroups",
                table: "TrainingOrderTrainerGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainerTrainingOrders",
                table: "TrainerTrainingOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainerGroupEmployees",
                table: "TrainerGroupEmployees");

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

            migrationBuilder.RenameTable(
                name: "TrainingOrderTrainerGroups",
                newName: "TrainerGroupTrainingOrder");

            migrationBuilder.RenameTable(
                name: "TrainerTrainingOrders",
                newName: "EmployeeTrainingOrder");

            migrationBuilder.RenameTable(
                name: "TrainerGroupEmployees",
                newName: "EmployeeTrainerGroup");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingOrderTrainerGroups_TrainingOrdersId",
                table: "TrainerGroupTrainingOrder",
                newName: "IX_TrainerGroupTrainingOrder_TrainingOrdersId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainerTrainingOrders_TrainingOrdersAsTrainerId",
                table: "EmployeeTrainingOrder",
                newName: "IX_EmployeeTrainingOrder_TrainingOrdersAsTrainerId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainerGroupEmployees_TrainersId",
                table: "EmployeeTrainerGroup",
                newName: "IX_EmployeeTrainerGroup_TrainersId");

            migrationBuilder.AddColumn<int>(
                name: "ParentSkillId",
                table: "TrainingOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserAccountId",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainerGroupTrainingOrder",
                table: "TrainerGroupTrainingOrder",
                columns: new[] { "TrainerGroupsId", "TrainingOrdersId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeTrainingOrder",
                table: "EmployeeTrainingOrder",
                columns: new[] { "TrainersId", "TrainingOrdersAsTrainerId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeTrainerGroup",
                table: "EmployeeTrainerGroup",
                columns: new[] { "TrainerGroupId", "TrainersId" });

            migrationBuilder.CreateTable(
                name: "LessonSkill",
                columns: table => new
                {
                    LessonsId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonSkill", x => new { x.LessonsId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_LessonSkill_Lessons_LessonsId",
                        column: x => x.LessonsId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonSkill_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad713ab0-3e23-4fe5-bbd9-7e2e45cf87c3", null, "admin", "ADMIN" },
                    { "c3758f3a-2d45-4325-8827-df8af9a51e83", null, "trainee", "TRAINEE" },
                    { "f266d721-f0f7-4698-b0cd-68413da31d41", null, "trainer", "TRAINER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingOrders_ParentSkillId",
                table: "TrainingOrders",
                column: "ParentSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EmployeeId",
                table: "AspNetUsers",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LessonSkill_SkillId",
                table: "LessonSkill",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Employees_EmployeeId",
                table: "AspNetUsers",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTrainerGroup_Employees_TrainersId",
                table: "EmployeeTrainerGroup",
                column: "TrainersId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTrainerGroup_TrainerGroups_TrainerGroupId",
                table: "EmployeeTrainerGroup",
                column: "TrainerGroupId",
                principalTable: "TrainerGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTrainingOrder_Employees_TrainersId",
                table: "EmployeeTrainingOrder",
                column: "TrainersId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTrainingOrder_TrainingOrders_TrainingOrdersAsTrainerId",
                table: "EmployeeTrainingOrder",
                column: "TrainingOrdersAsTrainerId",
                principalTable: "TrainingOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerGroupTrainingOrder_TrainerGroups_TrainerGroupsId",
                table: "TrainerGroupTrainingOrder",
                column: "TrainerGroupsId",
                principalTable: "TrainerGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerGroupTrainingOrder_TrainingOrders_TrainingOrdersId",
                table: "TrainerGroupTrainingOrder",
                column: "TrainingOrdersId",
                principalTable: "TrainingOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingOrders_Skills_ParentSkillId",
                table: "TrainingOrders",
                column: "ParentSkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Employees_EmployeeId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTrainerGroup_Employees_TrainersId",
                table: "EmployeeTrainerGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTrainerGroup_TrainerGroups_TrainerGroupId",
                table: "EmployeeTrainerGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTrainingOrder_Employees_TrainersId",
                table: "EmployeeTrainingOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTrainingOrder_TrainingOrders_TrainingOrdersAsTrainerId",
                table: "EmployeeTrainingOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerGroupTrainingOrder_TrainerGroups_TrainerGroupsId",
                table: "TrainerGroupTrainingOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerGroupTrainingOrder_TrainingOrders_TrainingOrdersId",
                table: "TrainerGroupTrainingOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingOrders_Skills_ParentSkillId",
                table: "TrainingOrders");

            migrationBuilder.DropTable(
                name: "LessonSkill");

            migrationBuilder.DropIndex(
                name: "IX_TrainingOrders_ParentSkillId",
                table: "TrainingOrders");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EmployeeId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainerGroupTrainingOrder",
                table: "TrainerGroupTrainingOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeTrainingOrder",
                table: "EmployeeTrainingOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeTrainerGroup",
                table: "EmployeeTrainerGroup");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad713ab0-3e23-4fe5-bbd9-7e2e45cf87c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3758f3a-2d45-4325-8827-df8af9a51e83");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f266d721-f0f7-4698-b0cd-68413da31d41");

            migrationBuilder.DropColumn(
                name: "ParentSkillId",
                table: "TrainingOrders");

            migrationBuilder.RenameTable(
                name: "TrainerGroupTrainingOrder",
                newName: "TrainingOrderTrainerGroups");

            migrationBuilder.RenameTable(
                name: "EmployeeTrainingOrder",
                newName: "TrainerTrainingOrders");

            migrationBuilder.RenameTable(
                name: "EmployeeTrainerGroup",
                newName: "TrainerGroupEmployees");

            migrationBuilder.RenameIndex(
                name: "IX_TrainerGroupTrainingOrder_TrainingOrdersId",
                table: "TrainingOrderTrainerGroups",
                newName: "IX_TrainingOrderTrainerGroups_TrainingOrdersId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeTrainingOrder_TrainingOrdersAsTrainerId",
                table: "TrainerTrainingOrders",
                newName: "IX_TrainerTrainingOrders_TrainingOrdersAsTrainerId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeTrainerGroup_TrainersId",
                table: "TrainerGroupEmployees",
                newName: "IX_TrainerGroupEmployees_TrainersId");

            migrationBuilder.AlterColumn<string>(
                name: "UserAccountId",
                table: "Employees",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingOrderTrainerGroups",
                table: "TrainingOrderTrainerGroups",
                columns: new[] { "TrainerGroupsId", "TrainingOrdersId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainerTrainingOrders",
                table: "TrainerTrainingOrders",
                columns: new[] { "TrainersId", "TrainingOrdersAsTrainerId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainerGroupEmployees",
                table: "TrainerGroupEmployees",
                columns: new[] { "TrainerGroupId", "TrainersId" });

            migrationBuilder.CreateTable(
                name: "TrainingOrderSkill",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    TrainingOrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
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
                    { "8c6dcbe7-bc8b-4417-a76d-c0c79f45c79c", null, "trainee", "TRAINEE" },
                    { "caad8ec3-93f0-4ecf-a641-2a98dbe9fd75", null, "trainer", "TRAINER" },
                    { "ec0e96f5-3fe2-4fac-8205-cb8fc344fb2f", null, "admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserAccountId",
                table: "Employees",
                column: "UserAccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingOrderSkill_TrainingOrderId",
                table: "TrainingOrderSkill",
                column: "TrainingOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AspNetUsers_UserAccountId",
                table: "Employees",
                column: "UserAccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerGroupEmployees_Employees_TrainersId",
                table: "TrainerGroupEmployees",
                column: "TrainersId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerGroupEmployees_TrainerGroups_TrainerGroupId",
                table: "TrainerGroupEmployees",
                column: "TrainerGroupId",
                principalTable: "TrainerGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerTrainingOrders_Employees_TrainersId",
                table: "TrainerTrainingOrders",
                column: "TrainersId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerTrainingOrders_TrainingOrders_TrainingOrdersAsTrainerId",
                table: "TrainerTrainingOrders",
                column: "TrainingOrdersAsTrainerId",
                principalTable: "TrainingOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingOrderTrainerGroups_TrainerGroups_TrainerGroupsId",
                table: "TrainingOrderTrainerGroups",
                column: "TrainerGroupsId",
                principalTable: "TrainerGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingOrderTrainerGroups_TrainingOrders_TrainingOrdersId",
                table: "TrainingOrderTrainerGroups",
                column: "TrainingOrdersId",
                principalTable: "TrainingOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

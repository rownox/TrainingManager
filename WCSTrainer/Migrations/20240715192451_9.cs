using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations
{
    /// <inheritdoc />
    public partial class _9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_TrainerGroups_TrainerGroupId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingOrders_Employees_TraineeId",
                table: "TrainingOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Verifications_Employees_VerifierId",
                table: "Verifications");

            migrationBuilder.DropTable(
                name: "EmployeeSkill");

            migrationBuilder.DropTable(
                name: "EmployeeTrainerGroup");

            migrationBuilder.DropTable(
                name: "TrainingOrderTrainers");

            migrationBuilder.DropIndex(
                name: "IX_Employees_TrainerGroupId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skill",
                table: "Skill");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b86e3f8-2518-4869-90a8-c62af77f4821");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8256474a-dd83-4d24-ad92-ccb7ce10d4d3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3a26b34-6832-48b7-bfd2-b0c7a05dcf32");

            migrationBuilder.DropColumn(
                name: "TrainerGroupId",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Skill",
                newName: "Skills");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "VerifyDate",
                table: "Verifications",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<string>(
                name: "TrainerIds",
                table: "TrainingOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "VerificationId",
                table: "TrainingOrders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrainerIds",
                table: "TrainerGroups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SkillIds",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TrainingOrderIds",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skills",
                table: "Skills",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02457c7e-166d-49b9-8de5-b114ac994d97", null, "admin", "ADMIN" },
                    { "c294e7a3-1c42-46c2-bfbd-6cf8646b3531", null, "trainee", "TRAINEE" },
                    { "eb74c87c-e2d9-4e01-8317-e3c640c7d1ee", null, "trainer", "TRAINER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingOrders_VerificationId",
                table: "TrainingOrders",
                column: "VerificationId",
                unique: true,
                filter: "[VerificationId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingOrders_Employees_TraineeId",
                table: "TrainingOrders",
                column: "TraineeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingOrders_Verifications_VerificationId",
                table: "TrainingOrders",
                column: "VerificationId",
                principalTable: "Verifications",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Verifications_Employees_VerifierId",
                table: "Verifications",
                column: "VerifierId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingOrders_Employees_TraineeId",
                table: "TrainingOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingOrders_Verifications_VerificationId",
                table: "TrainingOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Verifications_Employees_VerifierId",
                table: "Verifications");

            migrationBuilder.DropIndex(
                name: "IX_TrainingOrders_VerificationId",
                table: "TrainingOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skills",
                table: "Skills");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02457c7e-166d-49b9-8de5-b114ac994d97");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c294e7a3-1c42-46c2-bfbd-6cf8646b3531");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb74c87c-e2d9-4e01-8317-e3c640c7d1ee");

            migrationBuilder.DropColumn(
                name: "TrainerIds",
                table: "TrainingOrders");

            migrationBuilder.DropColumn(
                name: "VerificationId",
                table: "TrainingOrders");

            migrationBuilder.DropColumn(
                name: "TrainerIds",
                table: "TrainerGroups");

            migrationBuilder.DropColumn(
                name: "SkillIds",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "TrainingOrderIds",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Skills",
                newName: "Skill");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "VerifyDate",
                table: "Verifications",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrainerGroupId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skill",
                table: "Skill",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "EmployeeSkill",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSkill", x => new { x.EmployeeId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_EmployeeSkill_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeSkill_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTrainerGroup",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    TrainerGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTrainerGroup", x => new { x.EmployeeId, x.TrainerGroupId });
                    table.ForeignKey(
                        name: "FK_EmployeeTrainerGroup_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeTrainerGroup_TrainerGroups_TrainerGroupId",
                        column: x => x.TrainerGroupId,
                        principalTable: "TrainerGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingOrderTrainers",
                columns: table => new
                {
                    TrainersId = table.Column<int>(type: "int", nullable: false),
                    TrainingOrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingOrderTrainers", x => new { x.TrainersId, x.TrainingOrderId });
                    table.ForeignKey(
                        name: "FK_TrainingOrderTrainers_Employees_TrainersId",
                        column: x => x.TrainersId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingOrderTrainers_TrainingOrders_TrainingOrderId",
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
                    { "7b86e3f8-2518-4869-90a8-c62af77f4821", null, "trainee", "TRAINEE" },
                    { "8256474a-dd83-4d24-ad92-ccb7ce10d4d3", null, "admin", "ADMIN" },
                    { "c3a26b34-6832-48b7-bfd2-b0c7a05dcf32", null, "trainer", "TRAINER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_TrainerGroupId",
                table: "Employees",
                column: "TrainerGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkill_SkillId",
                table: "EmployeeSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTrainerGroup_TrainerGroupId",
                table: "EmployeeTrainerGroup",
                column: "TrainerGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingOrderTrainers_TrainingOrderId",
                table: "TrainingOrderTrainers",
                column: "TrainingOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_TrainerGroups_TrainerGroupId",
                table: "Employees",
                column: "TrainerGroupId",
                principalTable: "TrainerGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingOrders_Employees_TraineeId",
                table: "TrainingOrders",
                column: "TraineeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Verifications_Employees_VerifierId",
                table: "Verifications",
                column: "VerifierId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

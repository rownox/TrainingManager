using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations {
    /// <inheritdoc />
    public partial class _11 : Migration {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_TrainerGroups_TrainerGroupId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_TrainerGroupId",
                table: "Employees");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09e92e70-3ce3-4dae-aa54-2ce355b8b3ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b9b2202-ff17-4870-9842-d61a32a3db58");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6db0fd16-de04-46a0-8d02-8c5d6d7f8c51");

            migrationBuilder.DropColumn(
                name: "TrainerGroupId",
                table: "Employees");

            migrationBuilder.CreateTable(
                name: "TrainerGroupEmployees",
                columns: table => new {
                    TrainerGroupId = table.Column<int>(type: "int", nullable: false),
                    TrainersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_TrainerGroupEmployees", x => new { x.TrainerGroupId, x.TrainersId });
                    table.ForeignKey(
                        name: "FK_TrainerGroupEmployees_Employees_TrainersId",
                        column: x => x.TrainersId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainerGroupEmployees_TrainerGroups_TrainerGroupId",
                        column: x => x.TrainerGroupId,
                        principalTable: "TrainerGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingOrderTrainerGroups",
                columns: table => new {
                    TrainerGroupsId = table.Column<int>(type: "int", nullable: false),
                    TrainingOrdersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_TrainingOrderTrainerGroups", x => new { x.TrainerGroupsId, x.TrainingOrdersId });
                    table.ForeignKey(
                        name: "FK_TrainingOrderTrainerGroups_TrainerGroups_TrainerGroupsId",
                        column: x => x.TrainerGroupsId,
                        principalTable: "TrainerGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingOrderTrainerGroups_TrainingOrders_TrainingOrdersId",
                        column: x => x.TrainingOrdersId,
                        principalTable: "TrainingOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "93afec21-9606-4bc9-8851-b290c5eb2df8", null, "trainer", "TRAINER" },
                    { "a57e68a1-d5ef-4192-993e-98e6d5589863", null, "trainee", "TRAINEE" },
                    { "d6a97a0d-f0c9-40f9-b9da-114ed3aa83ce", null, "admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainerGroupEmployees_TrainersId",
                table: "TrainerGroupEmployees",
                column: "TrainersId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingOrderTrainerGroups_TrainingOrdersId",
                table: "TrainingOrderTrainerGroups",
                column: "TrainingOrdersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable(
                name: "TrainerGroupEmployees");

            migrationBuilder.DropTable(
                name: "TrainingOrderTrainerGroups");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93afec21-9606-4bc9-8851-b290c5eb2df8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a57e68a1-d5ef-4192-993e-98e6d5589863");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6a97a0d-f0c9-40f9-b9da-114ed3aa83ce");

            migrationBuilder.AddColumn<int>(
                name: "TrainerGroupId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "09e92e70-3ce3-4dae-aa54-2ce355b8b3ad", null, "trainer", "TRAINER" },
                    { "5b9b2202-ff17-4870-9842-d61a32a3db58", null, "admin", "ADMIN" },
                    { "6db0fd16-de04-46a0-8d02-8c5d6d7f8c51", null, "trainee", "TRAINEE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_TrainerGroupId",
                table: "Employees",
                column: "TrainerGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_TrainerGroups_TrainerGroupId",
                table: "Employees",
                column: "TrainerGroupId",
                principalTable: "TrainerGroups",
                principalColumn: "Id");
        }
    }
}

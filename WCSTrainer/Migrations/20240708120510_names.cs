using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WCSTrainer.Migrations
{
    /// <inheritdoc />
    public partial class names : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "trainers",
                table: "TrainingOrder",
                newName: "Trainers");

            migrationBuilder.RenameColumn(
                name: "trainee",
                table: "TrainingOrder",
                newName: "Trainee");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "TrainingOrder",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "skill",
                table: "TrainingOrder",
                newName: "Skill");

            migrationBuilder.RenameColumn(
                name: "medium",
                table: "TrainingOrder",
                newName: "Medium");

            migrationBuilder.RenameColumn(
                name: "location",
                table: "TrainingOrder",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "endDate",
                table: "TrainingOrder",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "duration",
                table: "TrainingOrder",
                newName: "Duration");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "TrainingOrder",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "createDate",
                table: "TrainingOrder",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "beginDate",
                table: "TrainingOrder",
                newName: "BeginDate");

            migrationBuilder.RenameColumn(
                name: "priorityLevel",
                table: "TrainingOrder",
                newName: "Priority");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Trainers",
                table: "TrainingOrder",
                newName: "trainers");

            migrationBuilder.RenameColumn(
                name: "Trainee",
                table: "TrainingOrder",
                newName: "trainee");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "TrainingOrder",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Skill",
                table: "TrainingOrder",
                newName: "skill");

            migrationBuilder.RenameColumn(
                name: "Medium",
                table: "TrainingOrder",
                newName: "medium");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "TrainingOrder",
                newName: "location");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "TrainingOrder",
                newName: "endDate");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "TrainingOrder",
                newName: "duration");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "TrainingOrder",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "TrainingOrder",
                newName: "createDate");

            migrationBuilder.RenameColumn(
                name: "BeginDate",
                table: "TrainingOrder",
                newName: "beginDate");

            migrationBuilder.RenameColumn(
                name: "Priority",
                table: "TrainingOrder",
                newName: "priorityLevel");
        }
    }
}

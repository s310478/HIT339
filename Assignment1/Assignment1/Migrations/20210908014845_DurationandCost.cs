using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment1.Migrations
{
    public partial class DurationandCost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentAge",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "LessonDurationCost",
                table: "DurationCost");

            migrationBuilder.AddColumn<string>(
                name: "LessonCost",
                table: "DurationCost",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LessonDuration",
                table: "DurationCost",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LessonCost",
                table: "DurationCost");

            migrationBuilder.DropColumn(
                name: "LessonDuration",
                table: "DurationCost");

            migrationBuilder.AddColumn<int>(
                name: "StudentAge",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LessonDurationCost",
                table: "DurationCost",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

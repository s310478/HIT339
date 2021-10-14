using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment1.Migrations
{
    public partial class Letter2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Select",
                table: "Lesson");

            migrationBuilder.RenameColumn(
                name: "details",
                table: "Letter",
                newName: "Year");

            migrationBuilder.AddColumn<string>(
                name: "Account_Name",
                table: "Letter",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Account_Number",
                table: "Letter",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Amount",
                table: "Letter",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BSB",
                table: "Letter",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bank",
                table: "Letter",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Begin_comment",
                table: "Letter",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Payment_Final",
                table: "Letter",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reference_Number",
                table: "Letter",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Semester",
                table: "Letter",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Signature",
                table: "Letter",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentName",
                table: "Letter",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Student_FirstName",
                table: "Letter",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Student_LastName",
                table: "Letter",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Term",
                table: "Letter",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Term_Start",
                table: "Letter",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Account_Name",
                table: "Letter");

            migrationBuilder.DropColumn(
                name: "Account_Number",
                table: "Letter");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Letter");

            migrationBuilder.DropColumn(
                name: "BSB",
                table: "Letter");

            migrationBuilder.DropColumn(
                name: "Bank",
                table: "Letter");

            migrationBuilder.DropColumn(
                name: "Begin_comment",
                table: "Letter");

            migrationBuilder.DropColumn(
                name: "Payment_Final",
                table: "Letter");

            migrationBuilder.DropColumn(
                name: "Reference_Number",
                table: "Letter");

            migrationBuilder.DropColumn(
                name: "Semester",
                table: "Letter");

            migrationBuilder.DropColumn(
                name: "Signature",
                table: "Letter");

            migrationBuilder.DropColumn(
                name: "StudentName",
                table: "Letter");

            migrationBuilder.DropColumn(
                name: "Student_FirstName",
                table: "Letter");

            migrationBuilder.DropColumn(
                name: "Student_LastName",
                table: "Letter");

            migrationBuilder.DropColumn(
                name: "Term",
                table: "Letter");

            migrationBuilder.DropColumn(
                name: "Term_Start",
                table: "Letter");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Letter",
                newName: "details");

            migrationBuilder.AddColumn<bool>(
                name: "Select",
                table: "Lesson",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

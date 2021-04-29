using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoSocialAPI.Migrations
{
    public partial class AlterStudentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "attendence",
                table: "student",
                newName: "attendance");

            migrationBuilder.AlterColumn<string>(
                name: "avatarUrl",
                table: "student",
                type: "varchar(255) CHARACTER SET utf8mb4",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50) CHARACTER SET utf8mb4",
                oldMaxLength: 50,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "attendance",
                table: "student",
                newName: "attendence");

            migrationBuilder.AlterColumn<string>(
                name: "avatarUrl",
                table: "student",
                type: "varchar(50) CHARACTER SET utf8mb4",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255) CHARACTER SET utf8mb4",
                oldMaxLength: 255,
                oldNullable: true);
        }
    }
}

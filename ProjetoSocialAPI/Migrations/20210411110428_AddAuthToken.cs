using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoSocialAPI.Migrations
{
    public partial class AddAuthToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TokenId",
                table: "person",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "token",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    token = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", maxLength: 255, nullable: false),
                    token_refresh_time = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    deleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modificated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    created_by = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    modificated_by = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_token", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_person_TokenId",
                table: "person",
                column: "TokenId");

            migrationBuilder.AddForeignKey(
                name: "FK_person_token_TokenId",
                table: "person",
                column: "TokenId",
                principalTable: "token",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_person_token_TokenId",
                table: "person");

            migrationBuilder.DropTable(
                name: "token");

            migrationBuilder.DropIndex(
                name: "IX_person_TokenId",
                table: "person");

            migrationBuilder.DropColumn(
                name: "TokenId",
                table: "person");
        }
    }
}

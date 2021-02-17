using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Squad3.Migrations
{
    public partial class FirstDetails_ForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "UsersFirstDetailsInfoCores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UsersFirstDetailsInfoCores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UsersFirstDetailsInfoCores_UserId",
                table: "UsersFirstDetailsInfoCores",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersFirstDetailsInfoCores_Users_UserId",
                table: "UsersFirstDetailsInfoCores",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersFirstDetailsInfoCores_Users_UserId",
                table: "UsersFirstDetailsInfoCores");

            migrationBuilder.DropIndex(
                name: "IX_UsersFirstDetailsInfoCores_UserId",
                table: "UsersFirstDetailsInfoCores");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "UsersFirstDetailsInfoCores");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UsersFirstDetailsInfoCores");
        }
    }
}

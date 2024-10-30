using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_smarthome.Migrations
{
    /// <inheritdoc />
    public partial class SEHUser_DDL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Devicess",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UsersId",
                table: "Devicess",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Devicess_UsersId",
                table: "Devicess",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Devicess_Users_UsersId",
                table: "Devicess",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devicess_Users_UsersId",
                table: "Devicess");

            migrationBuilder.DropIndex(
                name: "IX_Devicess_UsersId",
                table: "Devicess");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Devicess");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Devicess");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_smarthome.Migrations
{
    /// <inheritdoc />
    public partial class SEHUserV2_DDL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devicess_Users_UsersId",
                table: "Devicess");

            migrationBuilder.DropIndex(
                name: "IX_Devicess_UsersId",
                table: "Devicess");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Devicess");

            migrationBuilder.CreateIndex(
                name: "IX_Devicess_UserId",
                table: "Devicess",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Devicess_Users_UserId",
                table: "Devicess",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devicess_Users_UserId",
                table: "Devicess");

            migrationBuilder.DropIndex(
                name: "IX_Devicess_UserId",
                table: "Devicess");

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
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_smarthome.Migrations
{
    /// <inheritdoc />
    public partial class SEHCountryCodes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresss_CountryDb_CountryId",
                table: "Addresss");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CountryDb",
                table: "CountryDb");

            migrationBuilder.RenameTable(
                name: "CountryDb",
                newName: "Countrys");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countrys",
                table: "Countrys",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresss_Countrys_CountryId",
                table: "Addresss",
                column: "CountryId",
                principalTable: "Countrys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresss_Countrys_CountryId",
                table: "Addresss");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countrys",
                table: "Countrys");

            migrationBuilder.RenameTable(
                name: "Countrys",
                newName: "CountryDb");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CountryDb",
                table: "CountryDb",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresss_CountryDb_CountryId",
                table: "Addresss",
                column: "CountryId",
                principalTable: "CountryDb",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

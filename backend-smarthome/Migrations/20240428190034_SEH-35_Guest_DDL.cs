using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_smarthome.Migrations
{
    /// <inheritdoc />
    public partial class SEH35_Guest_DDL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Apartments_ApartmentId",
                table: "Guests");

            migrationBuilder.AlterColumn<int>(
                name: "ApartmentId",
                table: "Guests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Apartments_ApartmentId",
                table: "Guests",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Apartments_ApartmentId",
                table: "Guests");

            migrationBuilder.AlterColumn<int>(
                name: "ApartmentId",
                table: "Guests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Apartments_ApartmentId",
                table: "Guests",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

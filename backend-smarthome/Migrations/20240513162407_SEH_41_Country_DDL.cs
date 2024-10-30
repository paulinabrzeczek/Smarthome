using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend_smarthome.Migrations
{
    /// <inheritdoc />
    public partial class SEH_41_Country_DDL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Addresss");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Addresss",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CountryDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryDb", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CountryDb",
                columns: new[] { "Id", "Code", "Value" },
                values: new object[,]
                {
                    { 1, "AUSTRIA", "AT" },
                    { 2, "BELGIUM", "BE" },
                    { 3, "BULGARIA", "BG" },
                    { 4, "CROATIA", "HR" },
                    { 5, "CYPRUS", "CY" },
                    { 6, "CZECH REPUBLIC", "CZ" },
                    { 7, "DENMARK", "DK" },
                    { 8, "ESTONIA", "EE" },
                    { 9, "FINLAND", "FI" },
                    { 10, "FRANCE", "FR" },
                    { 11, "GERMANY", "DE" },
                    { 12, "GREECE", "GR" },
                    { 13, "HUNGARY", "HU" },
                    { 14, "IRELAND", "IE" },
                    { 15, "ITALY", "IT" },
                    { 16, "LATVIA", "LV" },
                    { 17, "LITHUANIA", "LT" },
                    { 18, "LUXEMBOURG", "LU" },
                    { 19, "MALTA", "MT" },
                    { 20, "NETHERLANDS", "NL" },
                    { 21, "POLAND", "PL" },
                    { 22, "PORTUGAL", "PT" },
                    { 23, "ROMANIA", "RO" },
                    { 24, "SLOVAKIA", "SK" },
                    { 25, "SLOVENIA", "SI" },
                    { 26, "SPAIN", "ES" },
                    { 27, "SWEDEN", "SE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresss_CountryId",
                table: "Addresss",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresss_CountryDb_CountryId",
                table: "Addresss",
                column: "CountryId",
                principalTable: "CountryDb",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresss_CountryDb_CountryId",
                table: "Addresss");

            migrationBuilder.DropTable(
                name: "CountryDb");

            migrationBuilder.DropIndex(
                name: "IX_Addresss_CountryId",
                table: "Addresss");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Addresss");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Addresss",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

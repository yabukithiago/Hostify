using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hostify.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInitialTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuartoAndar",
                table: "Quarto");

            migrationBuilder.DropColumn(
                name: "QuartoNumero",
                table: "Quarto");

            migrationBuilder.AddColumn<string>(
                name: "QuartoLocalizacao",
                table: "Quarto",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuartoLocalizacao",
                table: "Quarto");

            migrationBuilder.AddColumn<int>(
                name: "QuartoAndar",
                table: "Quarto",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuartoNumero",
                table: "Quarto",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}

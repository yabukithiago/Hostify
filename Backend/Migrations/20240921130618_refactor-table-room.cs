using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hostify.Migrations
{
    /// <inheritdoc />
    public partial class refactortableroom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdHotel",
                table: "Quarto",
                newName: "HotelIdUtilizador");

            migrationBuilder.CreateIndex(
                name: "IX_Quarto_HotelIdUtilizador",
                table: "Quarto",
                column: "HotelIdUtilizador");

            migrationBuilder.AddForeignKey(
                name: "FK_Quarto_Utilizador_HotelIdUtilizador",
                table: "Quarto",
                column: "HotelIdUtilizador",
                principalTable: "Utilizador",
                principalColumn: "IdUtilizador",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quarto_Utilizador_HotelIdUtilizador",
                table: "Quarto");

            migrationBuilder.DropIndex(
                name: "IX_Quarto_HotelIdUtilizador",
                table: "Quarto");

            migrationBuilder.RenameColumn(
                name: "HotelIdUtilizador",
                table: "Quarto",
                newName: "IdHotel");
        }
    }
}

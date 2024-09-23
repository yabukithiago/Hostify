using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hostify.Migrations
{
    /// <inheritdoc />
    public partial class refactreservationtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdHospede",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "PerNight",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "TotalCost",
                table: "Reserva");

            migrationBuilder.RenameColumn(
                name: "QuartoNumero",
                table: "Reserva",
                newName: "quartoIdQuarto");

            migrationBuilder.RenameColumn(
                name: "IdQuarto",
                table: "Reserva",
                newName: "hotelIdUtilizador");

            migrationBuilder.RenameColumn(
                name: "IdHotel",
                table: "Reserva",
                newName: "hospedeIdUtilizador");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_hospedeIdUtilizador",
                table: "Reserva",
                column: "hospedeIdUtilizador");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_hotelIdUtilizador",
                table: "Reserva",
                column: "hotelIdUtilizador");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_quartoIdQuarto",
                table: "Reserva",
                column: "quartoIdQuarto");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Quarto_quartoIdQuarto",
                table: "Reserva",
                column: "quartoIdQuarto",
                principalTable: "Quarto",
                principalColumn: "IdQuarto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Utilizador_hospedeIdUtilizador",
                table: "Reserva",
                column: "hospedeIdUtilizador",
                principalTable: "Utilizador",
                principalColumn: "IdUtilizador",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Utilizador_hotelIdUtilizador",
                table: "Reserva",
                column: "hotelIdUtilizador",
                principalTable: "Utilizador",
                principalColumn: "IdUtilizador",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Quarto_quartoIdQuarto",
                table: "Reserva");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Utilizador_hospedeIdUtilizador",
                table: "Reserva");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Utilizador_hotelIdUtilizador",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_hospedeIdUtilizador",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_hotelIdUtilizador",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_quartoIdQuarto",
                table: "Reserva");

            migrationBuilder.RenameColumn(
                name: "quartoIdQuarto",
                table: "Reserva",
                newName: "QuartoNumero");

            migrationBuilder.RenameColumn(
                name: "hotelIdUtilizador",
                table: "Reserva",
                newName: "IdQuarto");

            migrationBuilder.RenameColumn(
                name: "hospedeIdUtilizador",
                table: "Reserva",
                newName: "IdHotel");

            migrationBuilder.AddColumn<int>(
                name: "IdHospede",
                table: "Reserva",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PerNight",
                table: "Reserva",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalCost",
                table: "Reserva",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}

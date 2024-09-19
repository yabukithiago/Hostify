using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hostify.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRoomReservationTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FimReserva",
                table: "Reserva",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IdQuarto",
                table: "Reserva",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "InicioReserva",
                table: "Reserva",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "QuartoDisponivel",
                table: "Quarto",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FimReserva",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "IdQuarto",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "InicioReserva",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "QuartoDisponivel",
                table: "Quarto");
        }
    }
}

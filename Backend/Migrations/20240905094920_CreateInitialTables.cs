using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Hostify.Migrations
{
    /// <inheritdoc />
    public partial class CreateInitialTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    IdReserva = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdHotel = table.Column<int>(type: "integer", nullable: false),
                    IdHospede = table.Column<int>(type: "integer", nullable: false),
                    QuartoNumero = table.Column<int>(type: "integer", nullable: false),
                    TypeReserva = table.Column<string>(type: "text", nullable: false),
                    DescriptionReserva = table.Column<string>(type: "text", nullable: false),
                    PerNight = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalCost = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.IdReserva);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reserva");
        }
    }
}

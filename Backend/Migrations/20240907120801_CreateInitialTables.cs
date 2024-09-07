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
                name: "Quarto",
                columns: table => new
                {
                    IdQuarto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdHotel = table.Column<int>(type: "integer", nullable: false),
                    QuartoNumero = table.Column<int>(type: "integer", nullable: false),
                    QuartoTipo = table.Column<string>(type: "text", nullable: false),
                    QuartoDescricao = table.Column<string>(type: "text", nullable: false),
                    QuartoAndar = table.Column<int>(type: "integer", nullable: false),
                    QuartoCapacidade = table.Column<int>(type: "integer", nullable: false),
                    QuartoDiaria = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quarto", x => x.IdQuarto);
                });

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

            migrationBuilder.CreateTable(
                name: "Utilizador",
                columns: table => new
                {
                    IdUtilizador = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsernameUtilizador = table.Column<string>(type: "text", nullable: false),
                    PasswordUtilizador = table.Column<string>(type: "text", nullable: false),
                    NameUtilizador = table.Column<string>(type: "text", nullable: false),
                    TypeUtilizador = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizador", x => x.IdUtilizador);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quarto");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Utilizador");
        }
    }
}

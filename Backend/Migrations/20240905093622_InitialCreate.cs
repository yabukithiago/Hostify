using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Hostify.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hospede",
                columns: table => new
                {
                    IdHospede = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsernameUtilizador = table.Column<string>(type: "text", nullable: false),
                    PasswordUtilizador = table.Column<string>(type: "text", nullable: false),
                    NameUtilizador = table.Column<string>(type: "text", nullable: false),
                    TypeUtilizador = table.Column<string>(type: "text", nullable: false),
                    IdUtilizador = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospede", x => x.IdHospede);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    IdHotel = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsernameUtilizador = table.Column<string>(type: "text", nullable: false),
                    PasswordUtilizador = table.Column<string>(type: "text", nullable: false),
                    NameUtilizador = table.Column<string>(type: "text", nullable: false),
                    IdUtilizador = table.Column<int>(type: "integer", nullable: false),
                    TypeUtilizador = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.IdHotel);
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hospede");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "Quarto");
        }
    }
}

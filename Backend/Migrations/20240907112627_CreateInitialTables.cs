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
            migrationBuilder.DropTable(
                name: "Hospede");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hotel",
                table: "Hotel");

            migrationBuilder.RenameTable(
                name: "Hotel",
                newName: "Utilizador");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Utilizador",
                type: "character varying(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Utilizador",
                table: "Utilizador",
                column: "IdUtilizador");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Utilizador",
                table: "Utilizador");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Utilizador");

            migrationBuilder.RenameTable(
                name: "Utilizador",
                newName: "Hotel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hotel",
                table: "Hotel",
                column: "IdUtilizador");

            migrationBuilder.CreateTable(
                name: "Hospede",
                columns: table => new
                {
                    IdUtilizador = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameUtilizador = table.Column<string>(type: "text", nullable: false),
                    PasswordUtilizador = table.Column<string>(type: "text", nullable: false),
                    TypeUtilizador = table.Column<string>(type: "text", nullable: false),
                    UsernameUtilizador = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospede", x => x.IdUtilizador);
                });
        }
    }
}

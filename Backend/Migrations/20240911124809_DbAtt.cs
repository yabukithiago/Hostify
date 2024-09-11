using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hostify.Migrations
{
    /// <inheritdoc />
    public partial class DbAtt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Utilizador_UsernameUtilizador",
                table: "Utilizador",
                column: "UsernameUtilizador",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Utilizador_UsernameUtilizador",
                table: "Utilizador");
        }
    }
}

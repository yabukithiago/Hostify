using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hostify.Migrations
{
    /// <inheritdoc />
    public partial class updateuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailUtilizador",
                table: "Utilizador",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneUtilizador",
                table: "Utilizador",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailUtilizador",
                table: "Utilizador");

            migrationBuilder.DropColumn(
                name: "PhoneUtilizador",
                table: "Utilizador");
        }
    }
}

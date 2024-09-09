using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hostify.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRoomTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QuartoImagem",
                table: "Quarto",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuartoImagem",
                table: "Quarto");
        }
    }
}

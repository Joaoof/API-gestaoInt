using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoInt.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionMovement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Movements",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Movements");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pc2_progra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPetTypeAndStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Pets",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Pets",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Pets");
        }
    }
}

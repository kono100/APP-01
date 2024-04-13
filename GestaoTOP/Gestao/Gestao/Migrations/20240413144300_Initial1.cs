using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestao.Migrations
{
    /// <inheritdoc />
    public partial class Initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HrEntradaSeg",
                table: "Veiculo");

            migrationBuilder.DropColumn(
                name: "HrSaidaSeg",
                table: "Veiculo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HrEntradaSeg",
                table: "Veiculo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HrSaidaSeg",
                table: "Veiculo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

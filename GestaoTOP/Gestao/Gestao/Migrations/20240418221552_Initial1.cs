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
            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Visitante",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Visitante",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Complemento",
                table: "Visitante",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ddd",
                table: "Visitante",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gia",
                table: "Visitante",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ibge",
                table: "Visitante",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Localidade",
                table: "Visitante",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Visitante",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Siafi",
                table: "Visitante",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Uf",
                table: "Visitante",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Visitante");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Visitante");

            migrationBuilder.DropColumn(
                name: "Complemento",
                table: "Visitante");

            migrationBuilder.DropColumn(
                name: "Ddd",
                table: "Visitante");

            migrationBuilder.DropColumn(
                name: "Gia",
                table: "Visitante");

            migrationBuilder.DropColumn(
                name: "Ibge",
                table: "Visitante");

            migrationBuilder.DropColumn(
                name: "Localidade",
                table: "Visitante");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Visitante");

            migrationBuilder.DropColumn(
                name: "Siafi",
                table: "Visitante");

            migrationBuilder.DropColumn(
                name: "Uf",
                table: "Visitante");
        }
    }
}

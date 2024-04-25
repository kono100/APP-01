using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestao.Migrations
{
    /// <inheritdoc />
    public partial class Initial5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HrEntDom",
                table: "Veiculo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HrEntQua",
                table: "Veiculo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HrEntQui",
                table: "Veiculo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HrEntSab",
                table: "Veiculo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HrEntSeg",
                table: "Veiculo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HrEntSex",
                table: "Veiculo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HrSaiDom",
                table: "Veiculo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HrSaiQua",
                table: "Veiculo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HrSaiQui",
                table: "Veiculo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HrSaiSab",
                table: "Veiculo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HrSaiSeg",
                table: "Veiculo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HrSaiSex",
                table: "Veiculo",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HrEntDom",
                table: "Veiculo");

            migrationBuilder.DropColumn(
                name: "HrEntQua",
                table: "Veiculo");

            migrationBuilder.DropColumn(
                name: "HrEntQui",
                table: "Veiculo");

            migrationBuilder.DropColumn(
                name: "HrEntSab",
                table: "Veiculo");

            migrationBuilder.DropColumn(
                name: "HrEntSeg",
                table: "Veiculo");

            migrationBuilder.DropColumn(
                name: "HrEntSex",
                table: "Veiculo");

            migrationBuilder.DropColumn(
                name: "HrSaiDom",
                table: "Veiculo");

            migrationBuilder.DropColumn(
                name: "HrSaiQua",
                table: "Veiculo");

            migrationBuilder.DropColumn(
                name: "HrSaiQui",
                table: "Veiculo");

            migrationBuilder.DropColumn(
                name: "HrSaiSab",
                table: "Veiculo");

            migrationBuilder.DropColumn(
                name: "HrSaiSeg",
                table: "Veiculo");

            migrationBuilder.DropColumn(
                name: "HrSaiSex",
                table: "Veiculo");
        }
    }
}

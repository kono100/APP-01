using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestao.Migrations
{
    /// <inheritdoc />
    public partial class Initial10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HrSegunda",
                table: "Veiculo",
                newName: "HrEntradaSeg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HrEntradaSeg",
                table: "Veiculo",
                newName: "HrSegunda");
        }
    }
}

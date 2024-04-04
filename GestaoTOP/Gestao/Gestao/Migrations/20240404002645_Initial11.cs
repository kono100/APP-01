using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestao.Migrations
{
    /// <inheritdoc />
    public partial class Initial11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "HrEntTer",
                table: "Veiculo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "HrSaiTer",
                table: "Veiculo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HrEntTer",
                table: "Veiculo");

            migrationBuilder.DropColumn(
                name: "HrSaiTer",
                table: "Veiculo");
        }
    }
}

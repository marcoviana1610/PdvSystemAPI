using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PdvGrow.api.Migrations
{
    /// <inheritdoc />
    public partial class other : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Despesas",
                newName: "Descricao");

            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "Despesas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Despesas");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Despesas",
                newName: "Nome");
        }
    }
}

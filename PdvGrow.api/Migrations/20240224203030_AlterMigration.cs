using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PdvGrow.api.Migrations
{
    /// <inheritdoc />
    public partial class AlterMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VendaId",
                table: "NotasFiscais",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_NotasFiscais_VendaId",
                table: "NotasFiscais",
                column: "VendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotasFiscais_Vendas_VendaId",
                table: "NotasFiscais",
                column: "VendaId",
                principalTable: "Vendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotasFiscais_Vendas_VendaId",
                table: "NotasFiscais");

            migrationBuilder.DropIndex(
                name: "IX_NotasFiscais_VendaId",
                table: "NotasFiscais");

            migrationBuilder.DropColumn(
                name: "VendaId",
                table: "NotasFiscais");
        }
    }
}

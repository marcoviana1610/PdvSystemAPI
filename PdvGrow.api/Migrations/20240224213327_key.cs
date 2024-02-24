using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PdvGrow.api.Migrations
{
    /// <inheritdoc />
    public partial class key : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VendaProduto");

            migrationBuilder.AddColumn<string>(
                name: "ProdutoIds",
                table: "Vendas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProdutoIds",
                table: "Vendas");

            migrationBuilder.CreateTable(
                name: "VendaProduto",
                columns: table => new
                {
                    ProdutosVendidosId = table.Column<int>(type: "int", nullable: false),
                    VendasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendaProduto", x => new { x.ProdutosVendidosId, x.VendasId });
                    table.ForeignKey(
                        name: "FK_VendaProduto_Produtos_ProdutosVendidosId",
                        column: x => x.ProdutosVendidosId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VendaProduto_Vendas_VendasId",
                        column: x => x.VendasId,
                        principalTable: "Vendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VendaProduto_VendasId",
                table: "VendaProduto",
                column: "VendasId");
        }
    }
}

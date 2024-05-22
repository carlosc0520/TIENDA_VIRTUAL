using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TIENDA_VIRTUAL.Migrations
{
    public partial class actualizacionusuaEE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Categoria_ID_CATEGORIA",
                table: "Producto");

            migrationBuilder.RenameColumn(
                name: "ID_CATEGORIA",
                table: "Producto",
                newName: "CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_Producto_ID_CATEGORIA",
                table: "Producto",
                newName: "IX_Producto_CategoriaId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Categoria",
                newName: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Categoria_CategoriaId",
                table: "Producto",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Categoria_CategoriaId",
                table: "Producto");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "Producto",
                newName: "ID_CATEGORIA");

            migrationBuilder.RenameIndex(
                name: "IX_Producto_CategoriaId",
                table: "Producto",
                newName: "IX_Producto_ID_CATEGORIA");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "Categoria",
                newName: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Categoria_ID_CATEGORIA",
                table: "Producto",
                column: "ID_CATEGORIA",
                principalTable: "Categoria",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

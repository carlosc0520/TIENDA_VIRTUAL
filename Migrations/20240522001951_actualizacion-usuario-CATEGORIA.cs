using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TIENDA_VIRTUAL.Migrations
{
    public partial class actualizacionusuarioCATEGORIA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CATEGORIA",
                table: "Producto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ID_CATEGORIA",
                table: "Producto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRIPCION = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Producto_ID_CATEGORIA",
                table: "Producto",
                column: "ID_CATEGORIA");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Categoria_ID_CATEGORIA",
                table: "Producto",
                column: "ID_CATEGORIA",
                principalTable: "Categoria",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Categoria_ID_CATEGORIA",
                table: "Producto");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropIndex(
                name: "IX_Producto_ID_CATEGORIA",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "CATEGORIA",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "ID_CATEGORIA",
                table: "Producto");
        }
    }
}

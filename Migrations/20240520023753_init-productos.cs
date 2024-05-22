using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TIENDA_VIRTUAL.Migrations
{
    public partial class initproductos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBRE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DETALLE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PRECIO = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IMAGEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STOCK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Producto");
        }
    }
}

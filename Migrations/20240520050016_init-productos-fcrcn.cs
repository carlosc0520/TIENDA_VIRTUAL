using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TIENDA_VIRTUAL.Migrations
{
    public partial class initproductosfcrcn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FCRCN",
                table: "Producto",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FCRCN",
                table: "Producto");
        }
    }
}

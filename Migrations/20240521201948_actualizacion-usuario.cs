using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TIENDA_VIRTUAL.Migrations
{
    public partial class actualizacionusuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "APELLIDOM",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "APELLIDOP",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FECHA",
                table: "Usuario",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "NOMBRES",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ROL",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "APELLIDOM",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "APELLIDOP",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "FECHA",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "NOMBRES",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "ROL",
                table: "Usuario");
        }
    }
}

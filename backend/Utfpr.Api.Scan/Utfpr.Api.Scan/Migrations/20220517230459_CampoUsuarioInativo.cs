using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Utfpr.Api.Scan.Migrations
{
    public partial class CampoUsuarioInativo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoUsuario",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "RegistroAcademico",
                table: "AspNetUsers",
                newName: "Nome");

            migrationBuilder.AddColumn<bool>(
                name: "Inativo",
                table: "AspNetUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Inativo",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "AspNetUsers",
                newName: "RegistroAcademico");

            migrationBuilder.AddColumn<int>(
                name: "TipoUsuario",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}

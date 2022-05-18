using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Utfpr.Api.Scan.Migrations
{
    public partial class CheckinVinculoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Checkin",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Checkin_UsuarioId",
                table: "Checkin",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Checkin_AspNetUsers_UsuarioId",
                table: "Checkin",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkin_AspNetUsers_UsuarioId",
                table: "Checkin");

            migrationBuilder.DropIndex(
                name: "IX_Checkin_UsuarioId",
                table: "Checkin");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Checkin");
        }
    }
}

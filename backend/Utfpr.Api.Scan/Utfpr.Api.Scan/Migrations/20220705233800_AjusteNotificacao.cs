using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Utfpr.Api.Scan.Migrations
{
    public partial class AjusteNotificacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notificacoes_AspNetUsers_UsuarioId",
                table: "Notificacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notificacoes",
                table: "Notificacoes");

            migrationBuilder.RenameTable(
                name: "Notificacoes",
                newName: "Notificacao");

            migrationBuilder.RenameIndex(
                name: "IX_Notificacoes_UsuarioId",
                table: "Notificacao",
                newName: "IX_Notificacao_UsuarioId");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Notificacao",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CadastradoEm",
                table: "Notificacao",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notificacao",
                table: "Notificacao",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notificacao_AspNetUsers_UsuarioId",
                table: "Notificacao",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notificacao_AspNetUsers_UsuarioId",
                table: "Notificacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notificacao",
                table: "Notificacao");

            migrationBuilder.RenameTable(
                name: "Notificacao",
                newName: "Notificacoes");

            migrationBuilder.RenameIndex(
                name: "IX_Notificacao_UsuarioId",
                table: "Notificacoes",
                newName: "IX_Notificacoes_UsuarioId");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Notificacoes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CadastradoEm",
                table: "Notificacoes",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "NOW()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notificacoes",
                table: "Notificacoes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notificacoes_AspNetUsers_UsuarioId",
                table: "Notificacoes",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

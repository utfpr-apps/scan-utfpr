using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Utfpr.Api.Scan.Migrations
{
    public partial class Ambiente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ambiente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CodigoSala = table.Column<string>(type: "text", nullable: false),
                    TamanhoBloco = table.Column<byte>(type: "smallint", nullable: false),
                    CadastradoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ambiente", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ambiente");
        }
    }
}

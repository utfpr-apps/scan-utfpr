using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Utfpr.Api.Scan.Migrations
{
    public partial class Checkin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Checkin",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DataCheckin = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataFinalizacaoPermanencia = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AmbienteId = table.Column<Guid>(type: "uuid", nullable: false),
                    CadastradoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Checkin_Ambiente_AmbienteId",
                        column: x => x.AmbienteId,
                        principalTable: "Ambiente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Checkin_AmbienteId",
                table: "Checkin",
                column: "AmbienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Checkin");
        }
    }
}

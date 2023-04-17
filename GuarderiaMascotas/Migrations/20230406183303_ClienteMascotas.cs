using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuarderiaMascotas.Migrations
{
    /// <inheritdoc />
    public partial class ClienteMascotas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClienteMascotas",
                columns: table => new
                {
                    MascotaId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    FechaEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraEntrada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraSalida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactoAdicional = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteMascotas", x => new { x.MascotaId, x.ClienteId });
                    table.ForeignKey(
                        name: "FK_ClienteMascotas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClienteMascotas_Mascota_MascotaId",
                        column: x => x.MascotaId,
                        principalTable: "Mascota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClienteMascotas_ClienteId",
                table: "ClienteMascotas",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClienteMascotas");
        }
    }
}

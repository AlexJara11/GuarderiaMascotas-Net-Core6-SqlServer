using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuarderiaMascotas.Migrations
{
    /// <inheritdoc />
    public partial class MascotasClientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClienteMascotass");

            migrationBuilder.CreateTable(
                name: "MascotasClientes",
                columns: table => new
                {
                    MascotaId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    HoraEntrada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoraSalida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactoAdicional = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MascotasClientes", x => new { x.MascotaId, x.ClienteId });
                    table.ForeignKey(
                        name: "FK_MascotasClientes_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MascotasClientes_Mascota_MascotaId",
                        column: x => x.MascotaId,
                        principalTable: "Mascota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MascotasClientes_ClienteId",
                table: "MascotasClientes",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MascotasClientes");

            migrationBuilder.CreateTable(
                name: "ClienteMascotass",
                columns: table => new
                {
                    MascotaId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    ContactoAdicional = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    HoraEntrada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoraSalida = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteMascotass", x => new { x.MascotaId, x.ClienteId });
                    table.ForeignKey(
                        name: "FK_ClienteMascotass_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClienteMascotass_Mascota_MascotaId",
                        column: x => x.MascotaId,
                        principalTable: "Mascota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClienteMascotass_ClienteId",
                table: "ClienteMascotass",
                column: "ClienteId");
        }
    }
}

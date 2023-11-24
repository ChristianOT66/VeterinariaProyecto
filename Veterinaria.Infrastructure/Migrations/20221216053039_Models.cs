using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Veterinaria.Infrastructure.Migrations
{
    public partial class Models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dueno",
                columns: table => new
                {
                    IdDueno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Cedula = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dueno", x => x.IdDueno);
                });

            migrationBuilder.CreateTable(
                name: "Veterinarios",
                columns: table => new
                {
                    IdVeterinario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Cedula = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veterinarios", x => x.IdVeterinario);
                });

            migrationBuilder.CreateTable(
                name: "Mascota",
                columns: table => new
                {
                    IdMascota = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Raza = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    IdDueno = table.Column<int>(type: "int", nullable: false),
                    DuenoIdDueno = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mascota", x => x.IdMascota);
                    table.ForeignKey(
                        name: "FK_Mascota_Dueno_DuenoIdDueno",
                        column: x => x.DuenoIdDueno,
                        principalTable: "Dueno",
                        principalColumn: "IdDueno",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cita",
                columns: table => new
                {
                    IdCita = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdDueno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdVeterinario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VeterinarioIdVeterinario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cita", x => x.IdCita);
                    table.ForeignKey(
                        name: "FK_Cita_Veterinarios_VeterinarioIdVeterinario",
                        column: x => x.VeterinarioIdVeterinario,
                        principalTable: "Veterinarios",
                        principalColumn: "IdVeterinario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Historial",
                columns: table => new
                {
                    IdHistorial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdVeterinario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VeterinarioIdVeterinario = table.Column<int>(type: "int", nullable: true),
                    MotivoConsulta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diagnostico = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historial", x => x.IdHistorial);
                    table.ForeignKey(
                        name: "FK_Historial_Veterinarios_VeterinarioIdVeterinario",
                        column: x => x.VeterinarioIdVeterinario,
                        principalTable: "Veterinarios",
                        principalColumn: "IdVeterinario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cita_VeterinarioIdVeterinario",
                table: "Cita",
                column: "VeterinarioIdVeterinario");

            migrationBuilder.CreateIndex(
                name: "IX_Historial_VeterinarioIdVeterinario",
                table: "Historial",
                column: "VeterinarioIdVeterinario");

            migrationBuilder.CreateIndex(
                name: "IX_Mascota_DuenoIdDueno",
                table: "Mascota",
                column: "DuenoIdDueno");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cita");

            migrationBuilder.DropTable(
                name: "Historial");

            migrationBuilder.DropTable(
                name: "Mascota");

            migrationBuilder.DropTable(
                name: "Veterinarios");

            migrationBuilder.DropTable(
                name: "Dueno");
        }
    }
}

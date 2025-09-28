using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackEndVirONet8.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deportes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deportes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    PrimerApellido = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    SegundoApellido = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Sexo = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonaDeportes",
                columns: table => new
                {
                    PersonaId = table.Column<int>(type: "INTEGER", nullable: false),
                    DeporteId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaDeportes", x => new { x.PersonaId, x.DeporteId });
                    table.ForeignKey(
                        name: "FK_PersonaDeportes_Deportes_DeporteId",
                        column: x => x.DeporteId,
                        principalTable: "Deportes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonaDeportes_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Deportes",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Fútbol" },
                    { 2, "Básquetbol" },
                    { 3, "Tenis" },
                    { 4, "Natación" },
                    { 5, "Ciclismo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deportes_Nombre",
                table: "Deportes",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonaDeportes_DeporteId",
                table: "PersonaDeportes",
                column: "DeporteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonaDeportes");

            migrationBuilder.DropTable(
                name: "Deportes");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}

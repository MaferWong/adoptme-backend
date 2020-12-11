using Microsoft.EntityFrameworkCore.Migrations;

namespace Adopciones.Migrations
{
    public partial class CrearDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Refugios",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: true),
                    correoElectronico = table.Column<string>(nullable: true),
                    contrasena = table.Column<string>(nullable: true),
                    imagenURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refugios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Mascotas",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imagenURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    refugioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mascotas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Mascotas_Refugios_refugioId",
                        column: x => x.refugioId,
                        principalTable: "Refugios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_refugioId",
                schema: "dbo",
                table: "Mascotas",
                column: "refugioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mascotas",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Refugios");
        }
    }
}

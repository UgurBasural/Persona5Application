using Microsoft.EntityFrameworkCore.Migrations;

namespace Persona5APP.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arcanas",
                columns: table => new
                {
                    arcanaID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Arcananame = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arcanas", x => x.arcanaID);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    PersonaID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    PersonaName = table.Column<string>(nullable: true),
                    arcanaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.PersonaID);
                    table.ForeignKey(
                        name: "FK_Personas_Arcanas_arcanaID",
                        column: x => x.arcanaID,
                        principalTable: "Arcanas",
                        principalColumn: "arcanaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_arcanaID",
                table: "Personas",
                column: "arcanaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Arcanas");
        }
    }
}

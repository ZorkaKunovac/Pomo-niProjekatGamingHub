using Microsoft.EntityFrameworkCore.Migrations;

namespace PomoćniProjekatGamingHub.Migrations
{
    public partial class DodanaIgraKonzola : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IgraKonzola",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IgraID = table.Column<int>(nullable: false),
                    KonzolaID = table.Column<int>(nullable: false),
                    IsChecked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IgraKonzola", x => x.ID);
                    table.ForeignKey(
                        name: "FK_IgraKonzola_Igra_IgraID",
                        column: x => x.IgraID,
                        principalTable: "Igra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_IgraKonzola_Konzola_KonzolaID",
                        column: x => x.KonzolaID,
                        principalTable: "Konzola",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IgraKonzola_IgraID",
                table: "IgraKonzola",
                column: "IgraID");

            migrationBuilder.CreateIndex(
                name: "IX_IgraKonzola_KonzolaID",
                table: "IgraKonzola",
                column: "KonzolaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IgraKonzola");
        }
    }
}
